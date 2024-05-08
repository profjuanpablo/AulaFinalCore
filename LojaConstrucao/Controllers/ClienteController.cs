using Microsoft.AspNetCore.Mvc;
using LojaConstrucao.Models;
using System.Reflection.Metadata.Ecma335;

namespace LojaConstrucao.Controllers;

public class ClienteController : Controller
{
    //  "_clientes" é uma variável estática que simula um banco de dados temporário na memória para este exemplo.
    //  Ele é uma lista de clientes que é inicializada com alguns dados de exemplo no código do controlador.
    private static List<Cliente> _cliente = new List<Cliente>()
    {
        new Cliente { ClienteId= 1, NomeCliente="Juan" },
       new Cliente { ClienteId= 2, NomeCliente="Marcia" },
       new Cliente { ClienteId= 3, NomeCliente="Israel" },
        new Cliente { ClienteId= 4, NomeCliente="Pedro" }
   };


    public IActionResult Index()
    {
        return View(_cliente);
    }

    [HttpGet] //anotação de PEGAR
    public IActionResult Create() {  //chama o form de cadastro
        return View();
    }

    [HttpPost] //Anotação de ENVIAR
    public IActionResult Create(Cliente cliente) { //recebe os dados do form    

        if (ModelState.IsValid)
        {
                   // Térnario: se o valor de clienteId >0 então some + 1 a clienteId  senão atribua 1 ao clienteId
            cliente.ClienteId = _cliente.Count>0 ? _cliente.Max(c=>c.ClienteId)+1:1;
           
                   
            
            _cliente.Add(cliente);
        }
        return RedirectToAction("Index");
    }

 
    public IActionResult Delete(int id) {
        var cliente = _cliente.FirstOrDefault(c => c.ClienteId == id);
        if (cliente == null)
        {
            return NotFound();
        }

        _cliente.Remove(cliente);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id) {
        var cliente = _cliente.FirstOrDefault(c => c.ClienteId == id);
        if (cliente == null)
        {
            return NotFound();
        }

        return View(cliente);
    }


    

    [HttpPost]
    public IActionResult Edit(Cliente cliente)
    {
        if (ModelState.IsValid)
        {
            var existingCliente = _cliente.FirstOrDefault(c => c.ClienteId == cliente.ClienteId);
            if (existingCliente != null)
            {
                existingCliente.NomeCliente = cliente.NomeCliente;
                existingCliente.Email = cliente.Email;
            }
            return RedirectToAction("Index");
        }
        return View(cliente);
    }





}


