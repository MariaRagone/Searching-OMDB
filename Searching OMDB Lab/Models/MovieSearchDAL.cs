using static System.Net.WebRequestMethods;
using System.Net;
using Newtonsoft.Json;

namespace Searching_OMDB_Lab.Models
{ 
    public class MovieSearchDAL
{
    public static MovieModel GetMovie(string title)//adjust- use correct model, update method name
    {   //adjust
        //setup
        string url = $"https://www.omdbapi.com/?t={title}&apikey=38ffdea6";//link to API call

        //request data
        HttpWebRequest request = WebRequest.CreateHttp(url); //takes the url and calls the website and saves the call
        HttpWebResponse response = (HttpWebResponse)request.GetResponse(); //saves the response
                                                                           //converting to JSON
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd(); //takes all the info and saves it into a single string to use in our objects

        //adjust
        //converting to C#
        //right click on JsonConvert. > install Newtonsoft.json
        MovieModel result = JsonConvert.DeserializeObject<MovieModel>(json);//json is the string name
        return result;

    }
}
}

