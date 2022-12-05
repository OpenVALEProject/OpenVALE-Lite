using System.Collections;
using UnityEngine;

public class BurstCueTask : LocalizationTaskBase {

    // Track initial burst since that has to be played separately from normal moves
    private bool initialBurst = true;

    protected override void LoadAudioSource(Vector3 initialPosition) {
        songSourceNum = steamControl.LoadNoiseFile();
        steamControl.setAllSourceVolumes(1f);
        steamControl.moveSource(songSourceNum, initialPosition);
    }

    protected override void MoveAudioSource(Vector3 position) {
        steamControl.moveSource(songSourceNum, position);
        StartCoroutine(PlaybackCoroutine());
    }

    protected override void Update() {
        base.Update();
        if (initialBurst && userStarted) {
            // First burst after user started--play audio
            initialBurst = false;
            StartCoroutine(PlaybackCoroutine());
        }
    }

    public override void Reset() {
        base.Reset();
        initialBurst = true;
    }

    public override void Refresh() {
        base.Refresh();
        if (steamControl) {
            steamControl.reset();
        }
        LoadAudioSource(GetComponent<ALFLeds>().getSpeakerByID(speakerId).transform.position);
    }

    private IEnumerator PlaybackCoroutine() {
        if (songSourceNum == -1) {
            yield break;
        }

        steamControl.rewindClip(songSourceNum);
        steamControl.enableSource(songSourceNum, true);
        steamControl.muteSource(songSourceNum, false);

        yield return new WaitForSeconds(0.5f);

        steamControl.enableSource(songSourceNum, false);
        steamControl.muteSource(songSourceNum, true);
    }
}
