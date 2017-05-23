using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using FandF.Services;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net.Http;

namespace FandF.Services
{

    class APIController
    {
        List<ItemDBModel> api;
        private static readonly HttpClient client = new HttpClient();
        DBItemController db;
        public APIController()
        {
            db = new DBItemController();
        }

        public async void postJSON()
        {
            //Debug.WriteLine("***********************\n" + post.random +"\n" + "***********************\n");
            // Debug.WriteLine("***********************\n" + post.type + "\n" + "***********************\n");
            //Debug.WriteLine("***********************\n" + post.level + "\n" + "***********************\n");
            var postRequest = new Dictionary<string, string>
            {
            };
            var content = new FormUrlEncodedContent(postRequest);
            Debug.WriteLine("***********************\n" + " POSTING \n" + "***********************\n");
            var response = await client.PostAsync("http://gamehackathon.azurewebsites.net/api/GetItemsList", content);
            Debug.WriteLine("***********************\n" + " RECEIVING \n" + "***********************\n");
            var responseString = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(responseString);

            api = new List<ItemDBModel>();
            
            parseJSON(responseString);
            db.dropTable();
            db.createTable();
            foreach (ItemDBModel item in api)
            {
                db.SaveItem(item);
            }
        }

        public void parseJSON(string content)
        {
            JToken obj = JObject.Parse(content)["data"];
            foreach (JToken property in obj)
            {
                string attr = (string)property.SelectToken("AttribMod");
                if (attr.Equals("STRENGTH"))
                {
                    api.Add(new ItemDBModel
                    {
                        Name = (string)property.SelectToken("Name"),
                        Str = (int)property.SelectToken("Tier"),
                        URI = (string)property.SelectToken("Image"),
                        BodyPart = (string)property.SelectToken("BodyPart"),
                        Usage = (int)property.SelectToken("Usage"),
                    });
                }
                else if (attr.Equals("SPEED"))
                {
                    api.Add(new ItemDBModel
                    {
                        Name = (string)property.SelectToken("Name"),
                        Dex = (int)property.SelectToken("Tier"),
                        URI = (string)property.SelectToken("Image"),
                        BodyPart = (string)property.SelectToken("BodyPart"),
                        Usage = (int)property.SelectToken("Usage"),
                    });
                }
                else if (attr.Equals("HP"))
                {
                    api.Add(new ItemDBModel
                    {
                        Name = (string)property.SelectToken("Name"),
                        Health = (int)property.SelectToken("Tier"),
                        URI = (string)property.SelectToken("Image"),
                        BodyPart = (string)property.SelectToken("BodyPart"),
                        Usage = (int)property.SelectToken("Usage"),
                    });
                }
                else if (attr.Equals("DEFENSE"))
                {
                    api.Add(new ItemDBModel
                    {
                        Name = (string)property.SelectToken("Name"),
                        Def = (int)property.SelectToken("Tier"),
                        URI = (string)property.SelectToken("Image"),
                        BodyPart = (string)property.SelectToken("BodyPart"),
                        Usage = (int)property.SelectToken("Usage"),
                    });
                }
            }
        }
    }
}
