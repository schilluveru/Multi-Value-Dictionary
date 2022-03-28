using MultiValueDictionary.ClassLibrary.Interfaces;
using MultiValueDictionary.ClassLibrary.Repository;
using MultiValueDictionary.ClassLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MultiValueDictionary.Tests
{
    public class MultiValueDictionaryFacts
    {
         DictionaryRepository dictionaryRepository = new DictionaryRepository();

        public MultiValueDictionaryFacts()
        {
            
        }

        [Fact]
        public void Check_if_added_key_exists()
        {
            Dictionary<string, List<string>> test = new Dictionary<string, List<string>>();
            test.Add("Name", new List<string> { "Test" });

            dictionaryRepository.Add("Name", "Test");
            
            var result = dictionaryRepository.GetAllKeys();

            Assert.Equal("Name", result.First());

        }
    }
}
