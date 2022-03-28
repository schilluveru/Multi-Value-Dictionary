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
            var success = dictionaryRepository.Add("Name", "Test");

            var result = dictionaryRepository.GetAllKeys();

            Assert.True(success);
            Assert.Equal("Name", result.First());
        }

        [Fact]
        public void Check_if_the_key_is_removed()
        {
            dictionaryRepository.Add("Name", "Test");
            dictionaryRepository.Add("Job", "Engineer");

            var result = dictionaryRepository.RemoveKey("Name");

            Assert.True(result);
            Assert.Single(dictionaryRepository.GetAllKeys());
        }

        [Fact]
        public void Check_if_member_exists()
        {
            dictionaryRepository.Add("Name", "Test");
            dictionaryRepository.Add("Job", "Engineer");

            var result = dictionaryRepository.CheckIfMemberExist("Name", "Test");

            Assert.True(result);
            Assert.Contains("Test", dictionaryRepository.GetAllMembers());

        }

        [Fact]
        public void Check_if_member_that_is_removed_exists()
        {
            dictionaryRepository.Add("Name", "Test");
            dictionaryRepository.Add("Job", "Engineer");

            var result = dictionaryRepository.RemoveMember("Job", "Engineer");

            Assert.True(result);
            Assert.DoesNotContain("Engineer", dictionaryRepository.GetAllMembers());
        }

        [Fact]
        public void Return_empty_set_if_no_data_members_exists()
        {
            var result = dictionaryRepository.GetAllMembers();

            Assert.Empty(result);
        }

        [Theory]
        [InlineData("Job")]
        public void Check_if_all_returns_all_members_for_a_key(string key)
        {
            dictionaryRepository.Add(key, "Engineer" );
            dictionaryRepository.AddToExistingKey(key, "Doctor");

            var result = dictionaryRepository.GetAllMembersOfAKey(key);

            Assert.Equal(2, result.Count);
            Assert.Contains("Engineer", result);
        }

        [Fact]
        public void Check_if_all_keys_added_are_returned()
        {
            dictionaryRepository.Add("Name", "Test");
            dictionaryRepository.Add("Job", "Engineer");
            dictionaryRepository.Add("Car", "Audi");

            var result = dictionaryRepository.GetAllKeys();

            Assert.Equal(3, result.Count);
            Assert.Contains("Car", result);

        }

        [Fact]
        public void Check_if_all_members_added_are_returned()
        {
            dictionaryRepository.Add("Name", "Test");
            dictionaryRepository.Add("Job", "Engineer");
            dictionaryRepository.Add("Car", "Audi");

            var result = dictionaryRepository.GetAllMembers();

            Assert.Equal(3, result.Count);
            Assert.Contains("Audi", result);

        }

        [Fact]
        public void Check_no_data_exists_after_dictionary_is_cleared()
        {
            dictionaryRepository.Add("Name", "Test");
            dictionaryRepository.Add("Job", "Engineer");
            dictionaryRepository.Add("Car", "Audi");

            dictionaryRepository.ClearDictionary();

            Assert.Empty(dictionaryRepository.GetAllKeys());
        }

        [Fact]
        public void Return_false_if_key_doesnt_exists()
        {
            dictionaryRepository.Add("Name", "Test");
            dictionaryRepository.Add("Job", "Engineer");
            dictionaryRepository.Add("Car", "Audi");

            var result = dictionaryRepository.CheckIfKeyExist("Model");

            Assert.False(result);
        }

        [Fact]
        public void Return_false_if_member_doesnt_exists()
        {
            dictionaryRepository.Add("Name", "Test");
            dictionaryRepository.Add("Job", "Engineer");

            var result = dictionaryRepository.CheckIfMemberExist("Name", "Model");

            Assert.False(result);
        }

        [Fact]
        public void Return_empty_set_if_no_data_exists()
        {
            var result = dictionaryRepository.GetAllKeysAndValues();

            Assert.Empty(result);
        }


    }
}
