# NIF-PT-generator
API para geração de NIF Português

Para obter um número NIF aleatório é necessário introduzir o tipo do NIF:

- 1 a 3: Pessoa singular, a gama 3 começou a ser atribuída em junho de 2019;
- 45: Pessoa singular. Os algarismos iniciais "45" correspondem aos cidadãos não residentes que apenas obtenham em território português rendimentos sujeitos a retenção na fonte a título definitivo;
- 5: Pessoa colectiva obrigada a registo no Registo Nacional de Pessoas Colectivas;
- 6: Organismo da Administração Pública Central, Regional ou Local;
- 70, 74 e 75: Herança Indivisa, em que o autor da sucessão não era empresário individual, ou Herança Indivisa em que o cônjuge sobrevivo tem rendimentos comerciais;
- 71: Não residentes colectivos sujeitos a retenção na fonte a título definitivo;
- 72: Fundos de investimento;
- 77: Atribuição Oficiosa de NIF de sujeito passivo (entidades que não requerem NIF junto do RNPC);
- 78: Atribuição oficiosa a não residentes abrangidos pelo processo VAT REFUND;
- 79: Regime excepcional - [Expo 98](https://pt.wikipedia.org/wiki/Exposi%C3%A7%C3%A3o_Mundial_de_1998);
- 8: "empresário em nome individual" (actualmente obsoleto, já não é utilizado nem é válido);
- 90 e 91: Condomínios, Sociedade Irregulares, Heranças Indivisas cujo autor da sucessão era empresário individual;
- 98: Não residentes sem estabelecimento estável;
- 99: Sociedades civis sem personalidade jurídica.

Para verificar se o NIF valido, é necessário informar o NIF, o POST retornará true se for valido e false se for invalido


Exemplos URL:

GET 
https://nifptgenerator.azurewebsites.net/GenerateNif?typeNIF=

POST
https://nifptgenerator.azurewebsites.net/GenerateNif?nifNumber=
