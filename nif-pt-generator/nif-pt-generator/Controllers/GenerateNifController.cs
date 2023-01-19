using Microsoft.AspNetCore.Mvc;
using nif_pt_generator.Services;

namespace nif_pt_generator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenerateNifController : ControllerBase
    {
        [HttpGet(Name = "Generate")]
        public int Generate(int typeNIF)
        {
            /* 
                typeNIF equals:
                1 a 3: Pessoa singular, a gama 3 come�ou a ser atribu�da em junho de 2019;[2]
                45: Pessoa singular. Os algarismos iniciais "45" correspondem aos cidad�os n�o residentes que apenas obtenham em territ�rio portugu�s rendimentos sujeitos a reten��o na fonte a t�tulo definitivo;[3]
                5: Pessoa colectiva obrigada a registo no Registo Nacional de Pessoas Colectivas;[4]
                6: Organismo da Administra��o P�blica Central, Regional ou Local;
                70, 74 e 75: Heran�a Indivisa, em que o autor da sucess�o n�o era empres�rio individual, ou Heran�a Indivisa em que o c�njuge sobrevivo tem rendimentos comerciais;
                71: N�o residentes colectivos sujeitos a reten��o na fonte a t�tulo definitivo;
                72: Fundos de investimento;
                77: Atribui��o Oficiosa de NIF de sujeito passivo (entidades que n�o requerem NIF junto do RNPC);
                78: Atribui��o oficiosa a n�o residentes abrangidos pelo processo VAT REFUND;
                79: Regime excepcional - Expo 98;
                8: "empres�rio em nome individual" (actualmente obsoleto, j� n�o � utilizado nem � v�lido);
                90 e 91: Condom�nios, Sociedade Irregulares, Heran�as Indivisas cujo autor da sucess�o era empres�rio individual;
                98: N�o residentes sem estabelecimento est�vel;
                99: Sociedades civis sem personalidade jur�dica.
             */

            return GenerateNifServices.GenerateNif(typeNIF);

        }

        [HttpPost(Name = "IsValid")]
        public bool IsValid(string nifNumber)
        {
            return GenerateNifServices.IsValid(nifNumber);
        }
    }
}