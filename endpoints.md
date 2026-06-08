# API para sistema de gerenciamento de carteiras de vacinação

Foi utilizado o entendimento de que "registros de vacina" dependem do paciente para existir. Por isso, toda a manipulação deles passa por /api/persons.

## Autenticação

### POST /api/auth/register

Registra um novo usuário.

#### Request Body

```json
{
  "name": "john.doe",
  "password": "MySecurePassword123"
}
```

| Campo    | Tipo   | Obrigatório | Descrição        | Validações               |
| -------- | ------ | ----------- | ---------------- | ------------------------ |
| name     | string | Sim         | Nome de usuário  | Não vazio, tamanho < 255 |
| password | string | Sim         | Senha do usuário | Não vazio, tamanho < 255 |

#### Resposta de sucesso

**200 OK**

Usuário registrado com sucesso.

#### Respostas de erro

* 400 Bad Request — Parâmetros inválidos.
* 409 Conflict — Nome de usuário já existe.

---

### POST /api/auth/login

Autentica o usuário e retorna um token JWT.

#### Request Body

```json
{
  "name": "john.doe",
  "password": "MySecurePassword123"
}
```

| Campo    | Tipo   | Obrigatório | Descrição        | Validações               |
| -------- | ------ | ----------- | ---------------- | ------------------------ | 
| name     | string | Sim         | Nome de usuário  | Não vazio, tamanho < 255 |
| password | string | Sim         | Senha do usuário | Não vazio, tamanho < 255 |

#### Resposta de sucesso

**200 OK**

```json
{
  "token": "jwt-token"
}
```

#### Respostas de erro

* 401 Unauthorized — Credenciais inválidas.

---

# Pacientes (Persons)

### GET /api/persons

Lista todos os pacientes registrados.

#### Resposta de sucesso

**200 OK**

```json
[
  {
    "id": "a7fd4d97-f2dc-44af-a6ab-67df3dc40f2f",
    "name": "John Doe"
  }
]
```

#### Respostas de erro

* 401 Unauthorized

---

### POST /api/persons

Registra um novo paciente.

#### Request Body

```json
{
  "name": "John Doe"
}
```

| Campo | Tipo   | Obrigatório | Descrição        | Validações               |
| ----- | ------ | ----------- | ---------------- | ------------------------ |
| name  | string | Sim         | Nome do paciente | Não vazio, tamanho < 255 |

#### Resposta de sucesso

**200 OK**

```json
{
  "id": "a7fd4d97-f2dc-44af-a6ab-67df3dc40f2f"
}
```

#### Respostas de erro

* 400 Bad Request - parâmetros inválidos
* 401 Unauthorized

---

### GET /api/persons/{id}

Lista informações de um paciente a partir de sua GUID. Traz todas as informações de vacinações e informações da vacina associada.

#### Path Parameters

| Name | Tipo | Obrigatório | Descrição         | Validações |
| ---- | ---- | ----------- | ----------------- | ---------- |
| id   | uuid | Sim         | GUID do paciente  | Não vazio  |

#### Resposta de sucesso

**200 OK**

```json
{
  "id": "a7fd4d97-f2dc-44af-a6ab-67df3dc40f2f",
  "name": "John Doe",
  "vaccinations": [
    {
      "id": "f4c5ec58-6440-4d9f-a6d9-b7f2480a73b4",
      "vaccineId": "c5c6a1a4-67fb-4895-99e2-c56f8bc6a8a9",
      "doseNumber": 1,
      "applicationDate": "2025-05-15",
      "vaccine": {
        "name": "Vacina 1",
        "id": "c5c6a1a4-67fb-4895-99e2-c56f8bc6a8a9"
      }
    }
  ]
}
```

#### Respostas de erro

* 400 Bad Request - parâmetros inválidos
* 404 Not Found - paciente não encontrado
* 401 Unauthorized

---

### DELETE /api/persons/{id}

Deleta um paciente.

#### Path Parameters

| Name | Tipo | Obrigatório | Descrição         | Validações |
| ---- | ---- | ----------- | ----------------- | ---------- |
| id   | uuid | Sim         | GUID do paciente  | Não vazio  |

#### Resposta de sucesso

**204 NO CONTENT**

Paciente deletado com sucesso. Se o paciente não for encontrado, a resposta será a mesma.

#### Respostas de erro

* 400 Bad Request - parâmetros inválidos
* 401 Unauthorized

---

### POST /api/persons/{personId}/vaccinations

Cadastra um registro de vacinação para um paciente.

#### Path Parameters

| Name     | Tipo | Obrigatório | Descrição         | Validações |
| -------- | ---- | ----------- | ----------------- | ---------- |
| personId | uuid | Sim         | GUID do paciente  | Não vazio  |

#### Request Body

```json
{
  "vaccineId": "c5c6a1a4-67fb-4895-99e2-c56f8bc6a8a9",
  "doseNumber": 1,
  "applicationDate": "2025-05-15"
}
```

| Campo           | Tipo    | Obrigatório | Descrição            | Validações |
| --------------- | ------- | ----------- | -------------------- | ---------- |
| vaccineId       | uuid    | Sim         | GUID da vacina       | Não vazio  |
| doseNumber      | integer | Sim         | Número da dose       | >= 0       |
| applicationDate | date    | Sim         | Data da vacinação    |            |

#### Resposta de sucesso

**200 OK**

```json
{
  "id": "f4c5ec58-6440-4d9f-a6d9-b7f2480a73b4"
}
```

#### Respostas de erro

* 400 Bad Request - parâmetros inválidos / dose inválida
* 404 Not Found - paciente não encontrado
* 401 Unauthorized

---

### DELETE /api/persons/{personId}/vaccinations/{vaccinationId}

Remove um registro de vacinação de um paciente.

#### Path Parameters

| Name          | Tipo | Obrigatório | Descrição                     | Validações |
| ------------- | ---- | ----------- | ----------------------------- | ---------- |
| personId      | uuid | Sim         | GUID do paciente              | Não vazio  |
| vaccinationId | uuid | Sim         | GUID do registro de vacinação | Não vazio  |

#### Resposta de sucesso

**204 NO CONTENT**

Registro de vacinação removido com sucesso. Será retornada a mesma resposta caso o paciente seja encontrado, mas o registro de vacinação não.

#### Respostas de erro

* 404 Not Found - Paciente não encontrado
* 401 Unauthorized

---

# Vacinas (vaccines)

### GET /api/vaccines

Lista todas as vacinas registradas.

#### Resposta de sucesso

**200 OK**

```json
[
  {
    "id": "c5c6a1a4-67fb-4895-99e2-c56f8bc6a8a9",
    "name": "COVID-19"
  }
]
```

#### Respostas de erro

* 401 Unauthorized

---

### POST /api/vaccines

Cria uma nova vacina.

#### Request Body

```json
{
  "name": "COVID-19"
}
```

| Campo | Tipo   | Obrigatório | Descrição      | Validações               |
| ----- | ------ | ----------- | -------------- | ------------------------ |
| name  | string | Sim         | Nome da vacina | Não vazio, tamanho < 255 |

#### Resposta de sucesso

**200 OK**

```json
{
  "id": "c5c6a1a4-67fb-4895-99e2-c56f8bc6a8a9"
}
```

#### Respostas de erro

* 400 Bad Request - parâmetros inválidos
* 401 Unauthorized

---

### DELETE /api/vaccines/{vaccineId}

Deleta uma vacina.

#### Path Parameters

| Name      | Tipo | Obrigatório | Descrição          | Validações |
| --------- | ---- | ----------- | ------------------ | ---------- |
| vaccineId | uuid | Sim         | GUID da vacina     | Não vazio  |

#### Resposta de sucesso

**204 NO CONTENT**

Vacina deletada com sucesso. Será retornada a mesma resposta caso a vacina não seja encontrada.

#### Respostas de erro

* 401 Unauthorized

---

# Authentication

Todos os endpoints, exceto endpoints de autenticação, necessitam de um JWT bearer token.

```http
Authorization: Bearer <jwt-token>
```
