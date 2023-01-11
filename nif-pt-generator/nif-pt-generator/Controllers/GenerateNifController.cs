using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace nif_pt_generator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenerateNifController : ControllerBase
    {
        [HttpGet(Name = "GetWeatherForecast")]
        public int Get(int typeNIF)
        {
            /* 
             * typeNIF equals:
             *  1, 2, 3 - Pessoa Singular
             *  5 - Pessoa Colectiva
             *  6 - Pessoa Colectiva Publica
             *  8 - Empresario em nome indivudal
             *  9 - Pessoa colectiva irregular ou numero provisorio
             */
            int tamanhoNumero = 9;

            var sequence = Enumerable.Range(1, 10).OrderBy(n => n * n * (new Random()).Next());

            string nif = typeNIF.ToString();
            for (int i = 0; i < 7; i++)
            {
                nif = nif + (new Random()).Next(10);
            }

            string filteredNumber = Regex.Match(nif, @"[0-9]+").Value;

            int calculoCheckSum = 0;

            for (int i = 0; i < tamanhoNumero - 1; i++)
            {
                calculoCheckSum += (int.Parse(filteredNumber[i].ToString())) * (tamanhoNumero - i);
            }

            int digitoVerificacao = 11 - (calculoCheckSum % 11);

            if (digitoVerificacao > 9)
            {
                digitoVerificacao = 0;
            }

            nif = nif + digitoVerificacao;

            return Convert.ToInt32(nif);
        }


    }
}