using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ControllerIMC : ControllerBase
{
    [HttpGet]
    public IActionResult GetIMC(double peso, double altura)
    {
        if (altura <= 0 || peso <= 0)
        {
            return BadRequest("Peso e altura devem ser maiores que zero.");
        }

        double imc = peso / (altura * altura);
        string classificacao;

        if (imc < 18.5)
        {
            classificacao = "Magreza";
        }
        else if (imc < 24.9)
        {
            classificacao = "Normal";
        }
        else if (imc < 30)
        {
            classificacao = "Sobrepeso";
        }
        else
        {
            classificacao = "Obesidade";
        }

        var resultado = new
        {
            IMC = imc,
            Classificacao = classificacao
        };

        return Ok(resultado);
    }
}
