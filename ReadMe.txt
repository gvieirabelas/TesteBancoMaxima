Como executar a aplicação 
selecionar os dois projetos como principais e executar via visual studio, utilização do .netCore 3.1
Possível abrir APi via Swagger 
e a aplicação via console.


Estrutura 
Um console application pra receber os inputs de informação direto : Location do arquivo e string de rota final.
Uma WebApi para realizar consulta rest em .netCore 3.1, simples porem estruturada em model (contem os Dtos de entrada e saída) 
Controller(receptores de requisições)
Services(controladores/camada business/integration)
Mapper(para a abertura do arquivo)


A Api consiste em dois endpoints:
GetRoute : onde faz uma varredura entre todas as possíveis rotas, assim como o problema do caixeiro viajante, consiste em verificar todas as rotas possíveis e avaliar qual a melhor rota possível, através de somas e validações.

CreateNewRoute: Cria um novo caminho com Origem, Destino e Valor

