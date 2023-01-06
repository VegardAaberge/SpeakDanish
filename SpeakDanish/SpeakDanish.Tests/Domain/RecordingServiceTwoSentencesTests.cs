﻿using System;
using SpeakDanish.Domain;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Moq;
using SpeakDanish.Data;
using SpeakDanish.Domain.Models;
using System.Collections.Generic;
using SpeakDanish.Tests.Data;
using System.Linq;
using SpeakDanish.Data.Models;
using MathNet.Numerics.Distributions;

namespace SpeakDanish.Tests
{
    public class RecordingServiceTwoSentencesTests : IClassFixture<SpeakDanishDatabaseFixture>
    {
        private readonly IRecordingService _recordingService;
        private readonly string[] sentences = new string[] { "This is the previous sentence.", "This is another sentence." };

        public RecordingServiceTwoSentencesTests(SpeakDanishDatabaseFixture fixture)
        {
            _recordingService = new RecordingService(fixture.DatabaseMock.Object);

            List<SentenceEntity> sentenceEntities = sentences
                .Select(sentence => new SentenceEntity
                {
                    Sentence = sentence
                }).ToList();

            fixture.AddAllItem(sentenceEntities);
        }

        private void SetupFixture(ref IRecordingService recordingService, SpeakDanishDatabaseFixture fixture, string[] sentences)
        {
            recordingService = new RecordingService(fixture.DatabaseMock.Object);

            List<SentenceEntity> sentenceEntities = sentences
                .Select(sentence => new SentenceEntity
                {
                    Sentence = sentence
                }).ToList();

            fixture.AddAllItem(sentenceEntities);
        }

        [Fact]
        public async Task TestGetRandomSentence_ValidPreviousSentence()
        {
            // Arrange
            string previousSentence = sentences[0];
            string exptected = sentences[1];
            Task<string> getSentencesFromResources = Task.FromResult(string.Join("\n", sentences));

            // Act
            string result = await _recordingService.GetRandomSentence(previousSentence, getSentencesFromResources);

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().NotBe(previousSentence);
            result.Should().ContainAny(sentences);
            result.Should().Be(exptected);
        }

        [Fact]
        public async Task TestGetRandomSentence_ShouldFetchResource()
        {
            // Arrange
            string previousSentence = sentences[0];
            string[] resourceSentences = new string[] { "This is a sentence." };
            Task<string> getSentencesFromResources = Task.FromResult(string.Join("\n", resourceSentences));

            // Act
            string result = await _recordingService.GetRandomSentence(previousSentence, getSentencesFromResources);

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be(resourceSentences.First());
        }
    }
}

