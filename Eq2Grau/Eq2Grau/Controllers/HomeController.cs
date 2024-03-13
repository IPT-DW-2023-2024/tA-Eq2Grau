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

         // vars. auxiliares
         double auxA = 0, auxB = 0, auxC = 0;



         // 1.
         if (string.IsNullOrWhiteSpace(A) || string.IsNullOrWhiteSpace(B) || string.IsNullOrWhiteSpace(C)) {
            // enviar mensagem para o utilizador
            ViewBag.Mensagem = "Os par�metros A, B e C n�o podem ser vazios.";

            // devolver controlo � View
            return View();
         }

         // 1.
         if (!double.TryParse(A, out auxA)) {
            // o A n�o � n�mero.
            // enviar mensagem para o utilizador
            ViewBag.Mensagem = "O par�metro A tem de ser um n�mero";

            // devolver controlo � View
            return View();
         }

         // 1.
         if (!double.TryParse(B, out auxB)) {
            // o B n�o � n�mero.
            // enviar mensagem para o utilizador
            ViewBag.Mensagem = "O par�metro B tem de ser um n�mero";

            // devolver controlo � View
            return View();
         }

         // 1.
         if (!double.TryParse(C, out auxC)) {
            // o C n�o � n�mero.
            // enviar mensagem para o utilizador
            ViewBag.Mensagem = "O par�metro C tem de ser um n�mero";

            // devolver controlo � View
            return View();
         }


         // 2.
         if (auxA == 0) {
            // o A � ZERO.
            // enviar mensagem para o utilizador
            ViewBag.Mensagem = "O par�metro A n�o pode ser 0 (zero).";

            // devolver controlo � View
            return View();
         }


         // 3.
         double delta = Math.Pow(auxB, 2) - 4 * auxA * auxC;
         // 3.1
         if (delta > 0) {
            string x1 = Math.Round((-auxB + Math.Sqrt(delta)) / 2 / auxA, 2) + "";
            string x2 = Math.Round((-auxB - Math.Sqrt(delta)) / 2 / auxA, 2) + "";
            // enviar mensagem para o utilizador
            ViewBag.Mensagem = "Existem duas ra�zes reais distintas";
            ViewBag.X1 = x1;
            ViewBag.X2 = x2;

            // devolver controlo � View
            return View();
         }

         if (delta == 0) {
            string x = Math.Round(-auxB / 2 / auxA, 2) + "";
            // enviar mensagem para o utilizador
            ViewBag.Mensagem = "Existem duas ra�zes reais, mas iguais";
            ViewBag.X1 = x;
            ViewBag.X2 = x;

            // devolver controlo � View
            return View();
         }

         if (delta < 0) {
            string x1 = Math.Round((-auxB) / 2 / auxA, 2) + " + " + Math.Round(Math.Sqrt(-delta) / 2 / auxA, 2) + " i";
            string x2 = Math.Round((-auxB) / 2 / auxA, 2) + " - " + Math.Round(Math.Sqrt(-delta) / 2 / auxA, 2) + " i";
            // enviar mensagem para o utilizador
            ViewBag.Mensagem = "Existem duas ra�zes complexas conjugadas";
            ViewBag.X1 = x1;
            ViewBag.X2 = x2;

            // devolver controlo � View
            return View();
         }

         // se chegar aqui, alguma coisa correu muito mal...
         // devolver controlo � View
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
