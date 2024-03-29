﻿using System;
using System.Threading.Tasks;
using System.Timers;
using SpeakDanish.Contracts.Shared;

namespace SpeakDanish.Contracts.Domain
{
	public interface IAudioUseCase
	{
        /// <summary>
        /// Speak a sentence out loud.
        /// </summary>
        /// <param name="sentence">The sentence to speak.</param>
        /// <param name="volumeTimerCallback">A callback to be invoked when the volume timer elapsed event occurs.</param>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        Task<Response> SpeakSentenceAsync(string sentence, ElapsedEventHandler volumeTimerCallback);

        /// <summary>
        /// Start recording audio.
        /// </summary>
        /// <param name="countTimer">A callback to be invoked when the count timer elapsed event occurs.</param>
        /// <returns>A response containing the recorded audio path, or an error message if the operation failed.</returns>
        Task<Response<string>> StartRecordingAsync(string _filename, ElapsedEventHandler countTimer);

        /// <summary>
        /// Stop recording audio and save it to a file.
        /// </summary>
        /// <param name="filepath">The filepath where the recorded audio should be saved.</param>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        Task<Response> StopRecordingAsync(string filepath);

        Task<Response> PlayAudioAsync(string filepath, ElapsedEventHandler volumeTimerCallback);

        Task StartTranscribingDanish(ElapsedEventHandler countTimer, Action<Response<string>> recognizedCallback);

        Task StopTranscribingDanish(bool isCancelled);
    }
}

