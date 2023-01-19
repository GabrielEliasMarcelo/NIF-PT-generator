using System.Text.RegularExpressions;

namespace nif_pt_generator.Services
{
    public static class GenerateNifServices
    {
        public static int nifLength = 9;

        public static int GenerateNif(int typeNIF)
        {
            try
            {
                string nif = typeNIF.ToString();

                if (nif.Length > 2)
                {
                    throw new InvalidOperationException("Tipo NIF inválido! Favor verificar.");
                }

                TypeNifIsValid(typeNIF);

                int randomNumber = 7;
                if (nif.Length == 2)
                {
                    randomNumber = 6;
                }

                for (int i = 0; i < randomNumber; i++)
                {
                    nif = nif + (new Random()).Next(10);
                }

                string filteredNumber = Regex.Match(nif, @"[0-9]+").Value;

                int checkDigit = VerifyLastDigit(filteredNumber);

                nif = nif + checkDigit;

                return Convert.ToInt32(nif);

            }
            catch (Exception)
            {
                throw;
            }

        }

        public static bool IsValid(string nif)
        {
            try
            {
                string filteredNumber = Regex.Match(nif, @"[0-9]+").Value;

                if (filteredNumber.Length != nifLength || int.Parse(filteredNumber[0].ToString()) == 0)
                {
                    return false;
                }

                int checkDigit = VerifyLastDigit(filteredNumber);

                return checkDigit == int.Parse(filteredNumber[nifLength - 1].ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static int VerifyLastDigit(string filteredNumber)
        {
            int calCheckSum = 0;

            for (int i = 0; i < nifLength - 1; i++)
            {
                calCheckSum += (int.Parse(filteredNumber[i].ToString())) * (nifLength - i);
            }

            int checkDigit = 11 - (calCheckSum % 11);

            if (checkDigit > 9)
            {
                checkDigit = 0;
            }

            return checkDigit;
        }

        private static void TypeNifIsValid(int nif)
        {
            if (nif == 8)
            {
                throw new InvalidOperationException("Tipo NIF inválido! Empresário em nome individual actualmente obsoleto, já não é utilizado nem é válido");
            }

            if (nif != 1 || nif != 2 || nif != 3 || nif != 45 || nif != 5 || nif != 6 || nif != 70 || nif != 74 ||
                nif != 75 || nif != 71 || nif != 72 || nif != 77 || nif != 78 || nif != 79 || nif != 90 ||
                nif != 91 || nif != 98 || nif != 99)
            {
                throw new InvalidOperationException("Tipo NIF inválido! Numero informado não está na lista dos aceites");
            }
        }
    }
}
