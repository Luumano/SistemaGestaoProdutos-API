Feature: Gerenciamento de Pedidos
  Como um cliente
  Quero criar um pedido
  Para que eu possa finalizar minha compra

  Scenario: Criar um pedido com itens válidos
    Given que um cliente chamado "João" deseja fazer um pedido
    When ele adiciona os seguintes itens ao pedido:
      | Nome        | Preço | Quantidade |
      | Fone Ouvido | 10.00 | 2          |
      | Mouse       | 15.00 | 1          |
    And ele confirma o pedido
    Then o pedido deve ter o status "Confirmado"
    And o valor total do pedido deve ser 35.00
