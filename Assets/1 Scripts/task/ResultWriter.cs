using System;
using System.IO;
using UnityEngine;

public class ResultWriter {

    private StreamWriter writer;

    public ResultWriter(string fullDirPath) {
        Directory.CreateDirectory(fullDirPath);
        writer = new StreamWriter(Path.Combine(fullDirPath, $"{DateTime.Now.ToString("yyyyMMdd_HHmmss")}_{ConfigurationUtil.cueMode}.csv"));
        // Header info
        writer.WriteLine("Target Speaker,Target F,Target L,Target T,Response Speaker,Response F, Response L,Response T,Error,Response Time,HRTF,File,Note");
    }

    public void WriteResult(string targetSpeaker, Vector3 targetFlt, string chosenSpeaker, Vector3 chosenFlt,
        double responseTime, string error, string hrtf, string fileName) {
        chosenFlt.ToString();
        writer.WriteLine($"{targetSpeaker},{targetFlt.x.ToString("0.0")},{targetFlt.y.ToString("0.0")},{targetFlt.z.ToString("0.0")},{chosenSpeaker}," +
            $"{chosenFlt.x.ToString("0.0")},{chosenFlt.y.ToString("0.0")},{chosenFlt.z.ToString("0.0")},{error},{responseTime},{hrtf},{fileName}," +
            $"\"{ConfigurationUtil.trialNote}\"");
    }

    public void Close() => writer.Close();
}
