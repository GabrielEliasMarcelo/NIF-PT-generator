using nif_pt_generator.Services;

namespace nif_pt_generator_tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GenerateNif_Error_TypeNIF_Size()
        {
            //Try to pass a diferent size in parameter
            int typeNif = (new Random()).Next(100, 999999999);

            Assert.Throws<InvalidOperationException>(() => GenerateNifServices.GenerateNif(typeNif));
            //Assert.IS<InvalidOperationException>(ex);
        }

        [Test]
        public void GenerateNif_Error_TypeNIF_Obsolete()
        {
            Assert.Throws<InvalidOperationException>(() => GenerateNifServices.GenerateNif(8));
        }

        [Test]
        public void GenerateNif_Error_TypeNIF_Diferent()
        {
            var exclude = new HashSet<int>() { 1, 2, 3, 45, 6, 70, 74, 75, 71, 72, 77, 78, 79, 90, 91, 98, 99 };
            var range = Enumerable.Range(0, 100).Where(i => !exclude.Contains(i));
            var rand = new Random();
            int index = rand.Next(0, 100 - exclude.Count);
            int typeNif = range.ElementAt(index);
            Assert.Throws<InvalidOperationException>(() => GenerateNifServices.GenerateNif(typeNif));
        }
    }
}