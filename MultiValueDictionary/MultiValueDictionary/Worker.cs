using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using MultiValueDictionary.ClassLibrary.Interfaces;
using System.Linq;

namespace MultiValueDictionary
{
    public class Worker
    {
        private readonly ILogger<Worker> _logger;
        private readonly IDictionaryService _dictionaryService;

        public Worker(ILogger<Worker> logger, IDictionaryService dictionaryService)
        {
            _logger = logger;
            _dictionaryService = dictionaryService;
        }
        public void Run()
        {
            bool finished = false;
            _logger.LogInformation("MultiValue Dictionary is being called");
            do
            {
                Console.WriteLine("Please enter your input");
                Console.WriteLine("Select from below:");
                Console.WriteLine("KEYS, MEMBERS, ADD, REMOVE, REMOVEALL, CLEAR, KEYEXISTS, MEMBEREXISTS, ALLMEMBERS, ITEMS");
                
                var userInput = Console.ReadLine().Split(' ').Where(x => x != string.Empty).ToList();
                var length = userInput.Count;

                switch(userInput[0])
                {
                    case "ADD":
                        if (length == 3)
                        { 
                            if(_dictionaryService.Add(userInput[1], userInput[2]))
                                Console.WriteLine("Added");
                            else
                                Console.WriteLine("ERROR, member already exists for key");
                        }
                        else
                        {
                            Console.WriteLine("Please enter valid input");
                        }
                        break;

                    case "REMOVE":
                        if (length == 3)
                        {
                            if (_dictionaryService.RemoveMember(userInput[1], userInput[2]))
                                Console.WriteLine("Removed");
                            else
                                Console.WriteLine("ERROR, member does not exists");
                        }
                        else
                        {
                            Console.WriteLine("Please enter valid input");
                        }
                        break;

                    case "KEYS":
                        var keys = _dictionaryService.GetAllKeys();
                        keys.ForEach(x => Console.WriteLine(x));
                        break;

                    case "MEMBERS":
                        if (length == 2)
                        {
                            var members = _dictionaryService.GetAllMembersOfAKey(userInput[1]);
                            if (members.Count > 0)
                            {
                                members.ForEach(x => Console.WriteLine(x));
                            }
                        }
                        else
                        {
                            Console.WriteLine("ERROR, key does not exist");
                        }
                        break;

                    case "REMOVEALL":
                        if (length == 2)
                        {
                            var members = _dictionaryService.RemoveKey(userInput[1]);
                            Console.WriteLine("Removed");
                        }
                        else
                        {
                            Console.WriteLine("ERROR, key does not exist");
                        }
                        break;

                    case "CLEAR":
                        if(length == 1)
                        {
                            _dictionaryService.ClearDictionary();
                            Console.WriteLine("Cleared");
                        }
                        else
                        {
                            Console.WriteLine("Please enter valid input");
                        }
                        break;

                    case "KEYEXISTS":
                        if (length == 2)
                        {
                            var result = _dictionaryService.CheckIfKeyExist(userInput[1]);
                            Console.WriteLine(result);
                        }
                        else
                        {
                            Console.WriteLine("Please enter valid input");
                        }
                        break;

                    case "MEMBEREXISTS":
                        if (length == 3)
                        {
                            var memberResult = _dictionaryService.CheckIfMemberExist(userInput[1], userInput[2]);
                            Console.WriteLine(memberResult);
                        }
                        else
                        {
                            Console.WriteLine("Please enter valid input");
                        }
                        break;

                    case "ALLMEMBERS":
                        if(length == 1)
                        {
                           var members = _dictionaryService.GetAllMembers();
                           members.ForEach(x => Console.WriteLine(x));
                        }
                        else
                        {
                            Console.WriteLine("Please enter valid input");
                        }
                        break;

                    case "ITEMS":
                        if (length == 1)
                        {
                            var members = _dictionaryService.GetAllKeysAndValues();
                            members.ForEach(x => Console.WriteLine(x));
                        }
                        else
                        {
                            Console.WriteLine("Please enter valid input");
                        }
                        break;

                    case "default":
                        Console.WriteLine("Please enter valid input"); 
                        break;

                }

                Console.WriteLine("want to continue {y/n}");
                string read = Console.ReadLine();
                char c = read.ToCharArray().FirstOrDefault();

                if (c == 'y')
                    finished = false;
                else
                    finished = true;

            } while (!finished);
        }

       
    }
}