using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinUP2018.Models;

namespace XamarinUP2018.Services
{
    public interface IHeroService
    {
        Task<List<Hero>> GetHeros();
    }

    public sealed class HeroService : IHeroService
    {
        private const int httpTimeout = 3000;

        private string GetApiUrl()
            => $"https://api.opendota.com/api/heroStats";

        public async Task<List<Hero>> GetHeros()
        {
            var response = "[]"; // Empty json array
            var httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromMilliseconds(httpTimeout);
            try
            {
                response = await httpClient.GetStringAsync(GetApiUrl());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return Hero.FromJson(response);
        }

    }


}
