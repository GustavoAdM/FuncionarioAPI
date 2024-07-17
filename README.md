# API RESTful para Gerenciamento de Funcionários
Esta API oferece endpoints para realizar as seguintes operações relacionadas a funcionários:

- Consulta:
  - ``` /api/Funcionario/consultar ``` : Consulta todos os funcionários cadastrados.
  - ``` /api/Funcionario/consultar/{id} ``` : Consulta um funcionário específico pelo ID.
- Cadastro:
  - ``` /api/Funcionario/cadastrar ``` : Cadastra novos funcionários.
- Edição:
  - ``` /api/Funcionario/editar ``` : Edita informações de um funcionário. Informe o ID na chave “Id” para atualizar os 
dados.
- Ativar/Inativar:
  - ``` /api/Funcionario/desativar/{id}/{status} ``` : Consulta o funcionário e altera o status de ativação (“ativo”) para true 
ou false.
- Exclusão:
  - ``` /api/Funcionario/excluir/{id} ``` : Exclui um funcionário pelo ID.
 
Type:
  - id = int
  - status = bool (true/false)

# Departamentos
0: RH
1: Financeiro
2: Compras
3: Atendimento
4: Vendedor
5: Zeladoria
6: Estoque

# Turnos
0: Manhã
1: Tarde
2: Noite
 
# Esquema de Dados
O retorno da API segue o seguinte esquema:
```
{
  "dados": [
    {
      "id": 0,
      "nome": "string",
      "sobrenome": "string",
      "departamento": "int",
      "ativo": true,
      "turno": "int",
      "dtDeCriacao": "DateTime",
      "dtDeAlteracao": "DateTime"
    }
  ],
  "mensagem": "string",
  "sucesso": "bool"
}
```
