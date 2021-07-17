using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.REPOSITORIO;

namespace TDD.NUnitTest
{
    public class MockBaseTeste
    {
        public Mock<IProdutoRepositorio> mockRepositorio = new Mock<IProdutoRepositorio>();
    }
}
