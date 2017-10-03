using System;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class SearchCom : MonoBehaviour
{
    //結果を挿入する先のSerialHandler
    public SerialHandler sh;
    //ハードウェア名(部分一致でおk)
    public String SearchWord;
    private String PortNum="COM0";
    
	void Awake() {
	    ProcessStart();
	}
    /// <summary>
    /// プロセスをたたく
    /// </summary>
    void ProcessStart()
    {
        Process p = new Process
        {
            StartInfo =
            {
                FileName =Directory.GetCurrentDirectory() + @"\GetComDevices.exe",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = false,
                RedirectStandardInput = false,
                CreateNoWindow = true
            }
        };
        //イベントハンドラの設定
        p.OutputDataReceived += OutputDataHandler;
        p.EnableRaisingEvents = true;
        p.Exited += Process_Exit;

        //実行
        p.Start();
        p.BeginOutputReadLine();
    }
    //出力を受け取るとたたかれる
    private void OutputDataHandler(object sender, DataReceivedEventArgs args)
    {
        if (!string.IsNullOrEmpty(args.Data))
        {
            if (args.Data.IndexOf(SearchWord) != -1)
            {
                PortNum = args.Data.Split('\t')[1].Trim();
                
            }
        }
    }
    //出力が終わったらSerialHandlerの設定用メソッドをたたく
    private void Process_Exit(object sender, EventArgs e)
    {
        sh.SetPortName(PortNum);
        Process proc = (Process)sender;
        proc.Kill();
    }
}
