using MultiValueDictionary.ClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiValueDictionary.ClassLibrary.Services
{
    public class DictionaryService: IDictionaryService
    {
        private readonly IDictionaryRepository _dictionaryRepository;
        public DictionaryService(IDictionaryRepository dictionaryRepository)
        {
            _dictionaryRepository = dictionaryRepository;
        }

        public bool Add(string key, string value)
        {
            if (CheckIfKeyExist(key))
            {
                if (!CheckIfMemberExist(key, value))
                {
                    return _dictionaryRepository.AddToExistingKey(key, value);
                }
            }
            else
            {
                return _dictionaryRepository.Add(key, value);
            }
            return false;
        }

        public bool CheckIfKeyExist(string key)
        {
            return _dictionaryRepository.CheckIfKeyExist(key);
        }

        public bool CheckIfMemberExist(string key, string member)
        {
            return _dictionaryRepository.CheckIfMemberExist(key, member);
        }

        public void ClearDictionary()
        {
            _dictionaryRepository.ClearDictionary();
        }

        public List<string> GetAllKeys()
        {
            return _dictionaryRepository.GetAllKeys();
        }

        public List<string> GetAllKeysAndValues()
        {
            return _dictionaryRepository.GetAllKeysAndValues();
        }

        public List<string> GetAllMembers()
        {
            return _dictionaryRepository.GetAllMembers();
        }

        public List<string> GetAllMembersOfAKey(string key)
        {
            if (CheckIfKeyExist(key))
            {
                return _dictionaryRepository.GetAllMembersOfAKey(key);
            }
            return new List<string>();
        }

        public bool RemoveKey(string key)
        {
            return _dictionaryRepository.RemoveKey(key);
        }

        public bool RemoveMember(string key, string value)
        {
            return _dictionaryRepository.RemoveMember(key, value);
        }
    }
}
