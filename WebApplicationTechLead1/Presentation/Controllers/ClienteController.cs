﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationTechLead1.Domain.Models;
using WebApplicationTechLead1.Domain.Repositories;
using WebApplicationTechLead1.Services;
using WebApplicationTechLead1.Services.Commands;
using WebApplicationTechLead1.Services.Handlers;
using WebApplicationTechLead1.Services.Queries;

namespace WebApplicationTechLead1.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;
        private readonly TesteQueryHandler _testeQueryHandler;

        public ClienteController(ClienteService clienteService, TesteQueryHandler testeQueryHandler)
        {
            _clienteService = clienteService;
            _testeQueryHandler = testeQueryHandler;
        }

        #region MONGODB

        // GET: api/cliente
        [HttpGet]
        [ProducesResponseType(typeof(List<Teste>), 200)]
        public async Task<ActionResult<List<Teste>>> GetAllTestes()
        {
            var query = new GetAllTestesQuery();
            var testesCollection = await _testeQueryHandler.Handle(query);
            return Ok(testesCollection);
        }


        // GET: api/cliente/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Teste), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Teste>> GetTesteById(string id)
        {
            var query = new GetTesteByIdQuery(id);
            var collectionTestes = await _testeQueryHandler.Handle(query);

            if (collectionTestes == null)
            {
                return NotFound();
            }

            return collectionTestes;
        }

        #endregion

        #region EntityFramework CRUD 
        // POST: api/cliente
        [HttpPost]
        [ProducesResponseType(typeof(Cliente), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Cliente>> AddCliente(AddClienteCommand command)
        {
            var cliente = new Cliente(command.NomeEmpresa, command.PorteEmpresa);

            await _clienteService.AddClienteAsync(cliente);

            return CreatedAtAction(nameof(GetClienteByIdQuery), new { id = cliente.Id }, cliente);
        }


        // PUT: api/cliente/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> UpdateCliente(int id, UpdateClienteCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var cliente = await _clienteService.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            var clienteAtualizado = new Cliente(command.NomeEmpresa, command.PorteEmpresa);

            await _clienteService.UpdateClienteAsync(id, clienteAtualizado);

            return Ok();
        }


        // DELETE: api/cliente/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteCliente(DeleteClienteCommand command)
        {
            var cliente = await _clienteService.GetClienteByIdAsync(command.Id);
            if (cliente == null)
            {
                return NotFound();
            }

            await _clienteService.DeleteClienteAsync(command.Id);

            return Ok();
        }

        #endregion
    }
}
