using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Arquivos;

namespace Alura.Adopet.Testes.Util
{
    public class PetAPartirDoCsvTest
    {

        [Fact]
        public void QuandoStringForValidaDeveRetornarUmPet()
        {
            //Arrange
            string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";

            //Act
            Pet pet = linha.ConverteDoTexto();

            //Assert
            Assert.NotNull(pet);
        }

        [Fact]
        public void QuandoStringForNulaDeveLancarArgumentNullException()
        {
            //Arrange
            string? linha = null;

            //Act + Assert
            Assert.Throws<ArgumentNullException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public void QuandoStringVaziaDeveLancarArgumentNullException()
        {
            //Arrange
            string? linha = null;

            //Act + Assert
            Assert.Throws<ArgumentNullException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public void QuandoCamposInsuficientesDeveLancarArgumentNullException()
        {
            //Arrange
            string? linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão";

            //Act + Assert
            Assert.Throws<ArgumentNullException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public void QuandoGuidInvalidoDeveLancarArgumentNullException()
        {
            //Arrange
            string? linha = "adasdasd1;Lima Limão;1";

            //Act + Assert
            Assert.Throws<ArgumentNullException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public void QuandoTipoInvalidoDeveLancarArgumentNullException()
        {
            //Arrange
            string? linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;3";

            //Act + Assert
            Assert.Throws<ArgumentNullException>(() => linha.ConverteDoTexto());
        }
    }
}
