﻿using SpeakDanish.Data.Mappers;
using SpeakDanish.Data.Models;
using SpeakDanish.Domain.Models;
using SpeakDanish.Data.Database;
using SpeakDanish.Contracts.Domain;

namespace SpeakDanish.Domain.Services
{
    public class RecordingService : IRecordingService<Recording>
    {
        private ISpeakDanishDatabase _database;

        public RecordingService(
            ISpeakDanishDatabase speakDanishDatabase)
        {
            _database = speakDanishDatabase;
        }

        public async Task<List<Recording>> GetRecordingsAsync()
        {
            var recordings = await _database.GetItemsAsync<RecordingEntity>();

            return recordings
                .Select(r => r.ToRecording())
                .ToList();
        }

        public async Task<Recording?> GetRecordingAsync(int id)
        {
            var recording = await _database.GetItemAsync<RecordingEntity>(id);

            return recording?.ToRecording();
        }

        public Task<int> InsertRecordingAsync(Recording recording)
        {
            return _database.InsertItemAsync(recording.ToRecordingEntity());
        }

        public Task<int> DeleteRecordingAsync(Recording recording)
        {
            return _database.DeleteItemAsync(recording.ToRecordingEntity());
        }
    }
}

