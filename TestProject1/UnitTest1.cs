using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using generator;

namespace NET
{
    [TestClass]
    public class TextGeneratorTests
    {
        private readonly string bigramsFilePath = "./bigrams.csv";
        private readonly string wordFrequencyFilePath = "./ruscorpora_content.csv";

        // Тест: Проверка, что генератор на основе биграмм генерирует ненулевой текст
        [TestMethod]
        public void BigramGenerator_GeneratesNonEmptyText()
        {
            var generator = new BigramGenerator(bigramsFilePath);
            string result = generator.GenerateText(100);
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        // Тест: Проверка, что генератор на основе биграмм генерирует текст заданной длины
        [TestMethod]
        public void BigramGenerator_GeneratesTextOfCorrectLength()
        {
            var generator = new BigramGenerator(bigramsFilePath);
            string result = generator.GenerateText(100);
            Assert.AreEqual(100, result.Length);
        }

        // Тест: Проверка, что все биграммы в сгенерированном тексте являются допустимыми
        [TestMethod]
        public void BigramGenerator_UsesValidBigrams()
        {
            var generator = new BigramGenerator(bigramsFilePath);
            string result = generator.GenerateText(100);
            var bigrams = File.ReadAllLines(bigramsFilePath)
                              .Skip(1)
                              .Select(line => line.Split(',')[0])
                              .ToHashSet();

            for (int i = 0; i < result.Length - 1; i++)
            {
                string bigram = result.Substring(i, 2);
                Assert.IsTrue(bigrams.Contains(bigram));
            }
        }

        // Тест: Проверка, что генератор на основе частотных свойств слов генерирует ненулевой текст
        [TestMethod]
        public void WordFrequencyGenerator_GeneratesNonEmptyText()
        {
            var generator = new WordFrequencyGenerator(wordFrequencyFilePath);
            string result = generator.GenerateText(100);
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        // Тест: Проверка, что генератор на основе частотных свойств слов генерирует текст заданной длины
        [TestMethod]
        public void WordFrequencyGenerator_GeneratesTextOfCorrectLength()
        {
            var generator = new WordFrequencyGenerator(wordFrequencyFilePath);
            string result = generator.GenerateText(100);
            int wordCount = result.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
            Assert.AreEqual(100, wordCount);
        }

        // Тест: Проверка, что все слова в сгенерированном тексте являются допустимыми
        [TestMethod]
        public void WordFrequencyGenerator_UsesValidWords()
        {
            var generator = new WordFrequencyGenerator(wordFrequencyFilePath);
            string result = generator.GenerateText(100);
            var words = File.ReadAllLines(wordFrequencyFilePath)
                            .Skip(1)
                            .Select(line => line.Split(';')[1])
                            .ToHashSet();

            foreach (var word in result.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                Assert.IsTrue(words.Contains(word));
            }
        }

        // Тест: Проверка, что генератор на основе биграмм может генерировать длинный текст
        [TestMethod]
        public void BigramGenerator_CanGenerateLongText()
        {
            var generator = new BigramGenerator(bigramsFilePath);
            string result = generator.GenerateText(1000);
            Assert.AreEqual(1000, result.Length);
        }

        // Тест: Проверка, что генератор на основе частотных свойств слов может генерировать длинный текст
        [TestMethod]
        public void WordFrequencyGenerator_CanGenerateLongText()
        {
            var generator = new WordFrequencyGenerator(wordFrequencyFilePath);
            string result = generator.GenerateText(1000);
            int wordCount = result.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
            Assert.AreEqual(1000, wordCount);
        }

        // Тест: Проверка, что генератор на основе биграмм генерирует текст длиной 500 символов
        [TestMethod]
        public void BigramGenerator_TextIsReasonableLength500()
        {
            var generator = new BigramGenerator(bigramsFilePath);
            string result = generator.GenerateText(500);
            Assert.AreEqual(500, result.Length);
        }

        // Тест: Проверка, что генератор на основе частотных свойств слов генерирует текст длиной 500 слов
        [TestMethod]
        public void WordFrequencyGenerator_TextIsReasonableLength500()
        {
            var generator = new WordFrequencyGenerator(wordFrequencyFilePath);
            string result = generator.GenerateText(500);
            int wordCount = result.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
            Assert.AreEqual(500, wordCount);
        }

        // Тест: Проверка, что генератор на основе биграмм генерирует текст длиной 1000 символов
        [TestMethod]
        public void BigramGenerator_TextIsReasonableLength1000()
        {
            var generator = new BigramGenerator(bigramsFilePath);
            string result = generator.GenerateText(1000);
            Assert.AreEqual(1000, result.Length);
        }

        // Тест: Проверка, что генератор на основе частотных свойств слов генерирует текст длиной 1000 слов
        [TestMethod]
        public void WordFrequencyGenerator_TextIsReasonableLength1000()
        {
            var generator = new WordFrequencyGenerator(wordFrequencyFilePath);
            string result = generator.GenerateText(1000);
            int wordCount = result.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
            Assert.AreEqual(1000, wordCount);
        }
    }
}
