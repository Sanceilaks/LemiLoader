using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Security;
using System.Text;
using System.Windows.Forms;

namespace LemiLoader.Hacks.Inject
{
    public enum DllInjectionResult
    {
        DllNotFound,
        GameProcessNotFound,
        InjectionFailed,
        Success
    }

    interface ILoadLibrary
    {
        DllInjectionResult Inject(String dll, int pid);
        //bool Inject(String pathToDll, int pid);
    }

    class LoadLibrary : ILoadLibrary
    {
            static readonly IntPtr INTPTR_ZERO = (IntPtr)0;

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern int CloseHandle(IntPtr hObject);

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern IntPtr GetModuleHandle(string lpModuleName);

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, uint size, int lpNumberOfBytesWritten);

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress,
                IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

            static LoadLibrary _instance;

            public static LoadLibrary GetInstance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new LoadLibrary();
                    }
                    return _instance;
                }
            }

            public DllInjectionResult Inject(String dll, int pid)
            {
                if (!File.Exists(dll))
                {
                    return DllInjectionResult.DllNotFound;
                }

                if (pid == 0)
                {
                    return DllInjectionResult.GameProcessNotFound;
                }

                if (!bInject((uint)pid, dll))
                {
                    return DllInjectionResult.InjectionFailed;
                }

                return DllInjectionResult.Success;
            }

            bool bInject(uint pToBeInjected, string sDllPath)
            {
                IntPtr hndProc = OpenProcess((0x2 | 0x8 | 0x10 | 0x20 | 0x400), 1, pToBeInjected);

                if (hndProc == INTPTR_ZERO)
                {
                    return false;
                }

                MainForm.GetInstance().SetProgressBarValue(10);

                IntPtr lpLLAddress = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");

                if (lpLLAddress == INTPTR_ZERO)
                {
                    return false;
                }

                MainForm.GetInstance().SetProgressBarValue(40);

                IntPtr lpAddress = VirtualAllocEx(hndProc, (IntPtr)null, (IntPtr)sDllPath.Length, (0x1000 | 0x2000), 0X40);

                if (lpAddress == INTPTR_ZERO)
                {
                    return false;
                }

                MainForm.GetInstance().SetProgressBarValue(60);

                byte[] bytes = Encoding.ASCII.GetBytes(sDllPath);

                if (WriteProcessMemory(hndProc, lpAddress, bytes, (uint)bytes.Length, 0) == 0)
                {
                    return false;
                }

                MainForm.GetInstance().SetProgressBarValue(80);

                if (CreateRemoteThread(hndProc, (IntPtr)null, INTPTR_ZERO, lpLLAddress, lpAddress, 0, (IntPtr)null) == INTPTR_ZERO)
                {
                    return false;
                }

                MainForm.GetInstance().SetProgressBarValue(90);

                CloseHandle(hndProc);

                MainForm.GetInstance().SetProgressBarValue(100);

                return true;
       }
    }
 }
