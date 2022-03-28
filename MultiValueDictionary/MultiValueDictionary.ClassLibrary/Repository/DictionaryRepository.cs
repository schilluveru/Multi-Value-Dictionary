using MultiValueDictionary.ClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiValueDictionary.ClassLibrary.Repository
{
    public class DictionaryRepository: IDictionaryRepository
    {
        Dictionary<string, List<string>> myDictionary;
        public DictionaryRepository()
        {
            myDictionary = MyMultiValueDictionary.Instance.dictionary;
        }

        public bool Add(string key, string value)
        {
            myDictionary.Add(key, new List<string> { value });
            return true;
        }

        public bool AddToExistingKey(string key, string value)
        {
            if (myDictionary.TryGetValue(key, out var values))
            {
                values.Add(value);
                myDictionary[key] = values;
                return true;
            }
            return false;
        }

        public bool CheckIfKeyExist(string key)
        {
            return myDictionary.ContainsKey(key);
        }

        public bool CheckIfMemberExist(string key, string member)
        {
            if (myDictionary.TryGetValue(key, out var values))
            {
                if (values.Contains(member))
                    return true;
            }
            return false;
        }

        public bool RemoveKey(string key) => myDictionary.Remove(key);

        public bool RemoveMember(string key, string value)
        {
            if (myDictionary.TryGetValue(key, out var values))
            {
                if (values.Count == 1)
                {
                    RemoveKey(key);
                }

                values.Remove(value);
                myDictionary[key] = values;

                return true;
            }
            return false;
        }

        public List<string> GetAllKeys() => myDictionary.Keys.ToList();

        public List<string> GetAllMembers() => myDictionary.Values.SelectMany(x => x).ToList();

        public List<string> GetAllMembersOfAKey(string key)
        {
            return myDictionary[key];
        }

        public List<string> GetAllKeysAndValues()
        {
            return myDictionary.SelectMany(x => x.Value.Select(y => x.Key + ":" + y)).ToList();
        }

        public void ClearDictionary()
        {
            myDictionary.Clear();
        }



    }


    
}
