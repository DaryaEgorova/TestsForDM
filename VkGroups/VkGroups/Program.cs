using System;
using VkNet;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace GroupsVk
{
    class Program
    {
        static void Main(string[] args)
        {
            static int[] GetPrefix(string s) //создание префикс-функции
            {
                int[] result = new int[s.Length];
                result[0] = 0; //присваиваем первому элементу нулевое значение
                int index = 0;

                for (int i = 1; i < s.Length; i++)
                {
                    while (index >= 0 && s[index] != s[i]) { index--; }
                    index++;
                    result[i] = index;
                }
                return result;
            }

            static int FindSubstring(string pattern, string text) //поиск образца в строке
            {
                int res = -1;
                int[] pf = GetPrefix(pattern);
                int index = 0;


                for (int i = 0; i < text.Length; i++)
                {

                    while (index > 0 && pattern[index] != text[i]) { index = pf[index - 1]; }
                    if (pattern[index] == text[i]) index++;
                    if (index == pattern.Length)
                    {
                        return res = i - index + 1;
                    }
                }
                return res;
            }

            var api = new VkApi();

            api.Authorize(new ApiAuthParams
            {
                ApplicationId = ***,
                Login = "***",
                Password = "***",
                Settings = Settings.All,
                TwoFactorAuthorization = () =>
                {
                    Console.WriteLine("Enter Code:");
                    return Console.ReadLine();
                }
            });



            var users = api.Friends.Get(new FriendsGetParams()
            {
                UserId = 1,
                Count = 6

            });

            foreach (var u in users)
                Console.WriteLine(u.ToString());
            
            for (int i =0; i < users.Count; i++)
            {
                List <string> groupsList = new List <string>();
                var groups = users.Groups.Get(1);
            }

        }
    }
}