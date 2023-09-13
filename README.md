# AgendaDeTarefas
Olá se você esta vendo isso , significa que esta tentando rodar o meu projeto 
se este é o caso , por favor siga os passos abaixo:

PASSO 1 :
Ter o docker instalado 

Passo 2 :
após ter feito dowload do projeto , utilizar o prompt para ir até o diretorio do mesmo,
dentro do projeto 
Escrever o comando 
'docker compose up' 
no seu prompt de comando para poder subir o container

passo3:
após ter criado o banco de dados(postgres), por favor rodar a query abaixo no banco 
CREATE TABLE tarefas (
    titulo      varchar(100) NOT NULL,
    descricao   text,
    data        date,
    prioridade  integer,
    finalizada  boolean,
    hora_inicio timestamp without time zone,
    hora_fim    timestamp without time zone,
    id          bigint PRIMARY KEY GENERATED ALWAYS AS IDENTITY
);

passo 4: executar o programa
após rodar a query acima e ter funcionado tudo correto é so rodar o programa!
