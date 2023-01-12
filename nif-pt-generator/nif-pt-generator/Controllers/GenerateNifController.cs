using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace nif_pt_generator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenerateNifController : ControllerBase
    {
        public int tamanhoNumero = 9;

        [HttpGet(Name = "GetNif")]
        public int GetNif(int typeNIF)
        {
            /* 
                typeNIF equals:
                1 a 3: Pessoa singular, a gama 3 começou a ser atribuída em junho de 2019;[2]
                45: Pessoa singular. Os algarismos iniciais "45" correspondem aos cidadãos não residentes que apenas obtenham em território português rendimentos sujeitos a retenção na fonte a título definitivo;[3]
                5: Pessoa colectiva obrigada a registo no Registo Nacional de Pessoas Colectivas;[4]
                6: Organismo da Administração Pública Central, Regional ou Local;
                70, 74 e 75: Herança Indivisa, em que o autor da sucessão não era empresário individual, ou Herança Indivisa em que o cônjuge sobrevivo tem rendimentos comerciais;
                71: Não residentes colectivos sujeitos a retenção na fonte a título definitivo;
                72: Fundos de investimento;
                77: Atribuição Oficiosa de NIF de sujeito passivo (entidades que não requerem NIF junto do RNPC);
                78: Atribuição oficiosa a não residentes abrangidos pelo processo VAT REFUND;
                79: Regime excepcional - Expo 98;
                8: "empresário em nome individual" (actualmente obsoleto, já não é utilizado nem é válido);
                90 e 91: Condomínios, Sociedade Irregulares, Heranças Indivisas cujo autor da sucessão era empresário individual;
                98: Não residentes sem estabelecimento estável;
                99: Sociedades civis sem personalidade jurídica.
             */

            var sequence = Enumerable.Range(1, 10).OrderBy(n => n * n * (new Random()).Next());

            string nif = typeNIF.ToString();
            int quantidadeAleatorio = 7;
            if (nif.Length == 2)
            {
                quantidadeAleatorio = 6;
            }

            for (int i = 0; i < quantidadeAleatorio; i++)
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

        [HttpPost(Name = "ValidaNif")]
        public bool ValidaNif(string nifNumber)
        {
            string filteredNumber = Regex.Match(nifNumber, @"[0-9]+").Value;

            if (filteredNumber.Length != tamanhoNumero || int.Parse(filteredNumber[0].ToString()) == 0)
            {
                return false;
            }

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

            return digitoVerificacao == int.Parse(filteredNumber[tamanhoNumero - 1].ToString());

        }
    }
}