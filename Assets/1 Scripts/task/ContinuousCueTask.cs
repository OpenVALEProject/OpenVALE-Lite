using System.IO;
using UnityEngine;

public class ContinuousCueTask : LocalizationTaskBase {

    private string currentWavFile;
    private System.Random randomGenerator = new System.Random();

    protected override void LoadAudioSource(Vector3 initialPosition) {
        steamControl.LoadSong(initialPosition, GetWavFile(), sourceNum => {
            steamControl.setAllSourceVolumes(1f);
            songSourceNum = sourceNum;
            currentWavFile = ConfigurationUtil.wavFile;
        });
    }

    private string GetWavFile() {
        var wavDirPath = $@"{Application.streamingAssetsPath}\wav\{ConfigurationUtil.wavFile}";
        if (ConfigurationUtil.isWavDir) {
            var wavFiles = new DirectoryInfo(wavDirPath).GetFiles("*.wav", SearchOption.AllDirectories);
            var randomIndex = randomGenerator.Next(wavFiles.Length);
            return wavFiles[randomIndex].FullName;
        } else {
            return $"{wavDirPath}.wav";
        }
    }

    protected override void MoveAudioSource(Vector3 position) {
        steamControl.moveSource(songSourceNum, position);
    }

    protected override void HandlePositionUpdate(Vector3 position) {
        if (userStarted && !ConfigurationUtil.isWavDir) {
            MoveAudioSource(position);
        } else {
            LoadAudioSource(position);
        }
    }

    protected override void Update() {
        if (songSourceNum != -1 && !steamControl.IsSourcePlaying(songSourceNum)
                && userStarted && !sessionComplete) {
            steamControl.rewindClip(songSourceNum);
            steamControl.enableSource(songSourceNum, true);
            steamControl.muteSource(songSourceNum, false);
        }
        base.Update();
    }

    public override void Refresh() {
        base.Refresh();
        if (currentWavFile != ConfigurationUtil.wavFile || songSourceNum == -1) {
            songSourceNum = -1;
            if (steamControl) {
                steamControl.reset();
            }
            LoadAudioSource(GetComponent<ALFLeds>().getSpeakerByID(speakerId).transform.position);
            currentWavFile = ConfigurationUtil.wavFile;
        }
    }

}
