# AgendaDeTarefas
Olá se você esta vendo isso , significa que esta tentando rodar o meu projeto 
se este é o caso , por favor siga os passos abaixo:

PASSO 1 :
Ter o docker instalado 
baixar o DOTNET 5 
e o DOTNET 5 RUNTIME

PASSO 2 :
após ter feito dowload do projeto , utilizar o prompt ou terminal de sua escolha  para ir até o diretorio onde esta o projeto instalado,
assim que estiver dentro do projeto escrever o comando:
"docker compose up"   no seu prompt de comando para poder subir o container,
após ter feito isso  abrir um novo terminal enquanto o docker roda e colocar o comando "ip a" para que sejam exibidos os ips
normalmente o 2: vai ter algo similiar a  "inet 172.29.187.45" por exemplo , copie somente o ip e utilize ele como seu Host.
teste a conexão para verificar que é o ip correto.


PASSO 3:
utilize um  cliente de banco de dados postgre, pode ser PGadmin,Dbeaver ou outros.
com o container ainda rodando crie uma nova conexão no seu banco de dados utilize os dados presentes no arquivo "docker-compose.yml" para prencher a conexão


PASSO 4:
após ter criado o banco de dados(postgres), por favor rodar a query abaixo no banco para que o programa funcione corretamente
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

PASSO 5: executar o programa
após rodar a query acima e ter funcionado tudo correto é só executar  o projeto e voalá!
