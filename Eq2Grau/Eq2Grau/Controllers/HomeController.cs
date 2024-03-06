using Eq2Grau.Models;

using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace Eq2Grau.Controllers {
   public class HomeController : Controller {
      private readonly ILogger<HomeController> _logger;

      public HomeController(ILogger<HomeController> logger) {
         _logger = logger;
      }


      /// <summary>
      /// Este m�todo � a 'porta de entrada' no programa
      /// </summary>
      /// <param name="A">coeficiente do par�metro X^2</param>
      /// <param name="B">coeficiente do par�metro X</param>
      /// <param name="C">coeficiente do par�metro independente</param>
      /// <returns></returns>
      public IActionResult Index(string A, string B, string C) {
         /* ALGORITMO
          * 1.- Determinar se os par�metros fornecidos s�o n�meros
          *     se sim,
          *        2.- determinar de A =/= 0 (A<>0) (A!=0)
          *            se n�o,
          *               enviar mensagem de erro para utilizador
          *            se sim,
          *               3.- calcular as ra�zes
          *                   x1,x2 = (-b +/- sqrt(b^2-4ac))/2/a
          *                   3.1- calcular as ra�zes reais
          *                   3.2- calcular as ra�zes complexas, se existirem
          *                   3.3- enviar resposta para o utilizador
          *     se n�o,
          *        enviar mensagem de erro para o utilizador
          */ 

         return View();
      }

      public IActionResult Privacy() {
         return View();
      }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error() {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}
