using System;
using System.Collections.Generic;
using System.Text;

namespace MultiValueDictionary.ClassLibrary.Interfaces
{
    public interface IDictionaryRepository 
    {
        bool CheckIfKeyExist(string key);
        bool Add(string key, string value);
        bool AddToExistingKey(string key, string value);
        bool CheckIfMemberExist(string key, string member);
        bool RemoveKey(string key);
        bool RemoveMember(string key, string value);
        List<string> GetAllKeys();
        List<string> GetAllMembers();
        List<string> GetAllMembersOfAKey(string key);
        List<string> GetAllKeysAndValues();
        void ClearDictionary();
    }
}
