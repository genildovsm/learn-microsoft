## Criando uma Autoridade Certificadora Privada

~~~bash
sudo apt update
sudo apt install -y openssl
mkdir -p ca/newcerts
cd ca
touch index.txt
echo "1000" > serial 
cp /etc/ssl/openssl.cnf .
mkdir private
~~~

Após copiar o arquivo de configuração do openssl, deve ser gerada a chave privada que será usada para assinar os certificados.

~~~bash
openssl genrsa -aes256 -out private/cakey.pem 4096
~~~

Criar a RootCA que irá emitir os certificados para as certificadoras intermediárias.

~~~bash
openssl req -new -x509 -days 3650 -key private/cakey.pem -out cacert.pem
~~~

Ao executar o comando, as seguintes informações são solicitadas.

~~~
Enter pass phrase for private/cakey.pem:
You are about to be asked to enter information that will be incorporated
into your certificate request.
What you are about to enter is what is called a Distinguished Name or a DN.
There are quite a few fields but you can leave some blank
For some fields there will be a default value,
If you enter '.', the field will be left blank.
-----
Country Name (2 letter code) [AU]:BR
State or Province Name (full name) [Some-State]:Sao Paulo
Locality Name (eg, city) []:Praia Grande
Organization Name (eg, company) [Internet Widgits Pty Ltd]:Genildo Martins WebTips
Organizational Unit Name (eg, section) []:
Common Name (e.g. server FQDN or YOUR name) []:Odin
Email Address []:genildovsm@gmail.com
~~~

Para gerar os certificados, pode-se usar tanto a private key "cakey.pem" quanto a RootCA "cacert.pem". Normalmente a RootCA não gera certificados para usuários ou dispositivos finais, apenas para autoridades certificadoras intermediárias. Isso porque se a RootCA for comprometida, deverá ser recriada toda a hierarquia da unidade certificadora. usando sub CAs, permite-se revogar somente a unidade comprometida e gerar novos a partir da nova sub CA.

### Gerando certificados para usuários

Um exemplo de aplicação de certificados é conectar a um firewall fortigate. Para isso serão necessários 3 certificados, o RootCA que será importado no dispositivo e outro gerado exclusivamente para ele, outro para a máquina do usuário que irá estabelecer a conexão.  
  
Gerando uma chave privada para o dispositivo.

~~~bash
openssl genrsa -out fortigate-key.pem 4096
~~~

A partir dessa chave privada será criada uma solicitação de assinatura de certificado "Certificate Sign Request".

~~~bash
openssl req -new -key fortigate-key.pem -out fortigate.csr
~~~

Ao executar o comando, as seguintes informações serão solicitadas.

~~~bash
You are about to be asked to enter information that will be incorporated
into your certificate request.
What you are about to enter is what is called a Distinguished Name or a DN.
There are quite a few fields but you can leave some blank
For some fields there will be a default value,
If you enter '.', the field will be left blank.
-----
Country Name (2 letter code) [AU]:BR
State or Province Name (full name) [Some-State]:Sao Paulo
Locality Name (eg, city) []:Praia Grande
Organization Name (eg, company) [Internet Widgits Pty Ltd]:Genildo Martins WebTips
Organizational Unit Name (eg, section) []:Firewall Fortigate
Common Name (e.g. server FQDN or YOUR name) []:firewall-01
Email Address []:genildovsm@gmail.com

Please enter the following 'extra' attributes
to be sent with your certificate request
A challenge password []:admin@123
An optional company name []:
~~~

Agora devemos assinar essa requisição de assinatura "CSR" usando o certificado da RootCA.  
Para isso devemos alterar uma configuração de diretório dentro do arquivo **openssl.cnf**.  

Alterar a linha 82 do arquivo **openssl.cnf**, indicando o diretório anterior ao diretório "private", onde está a chave privada da RootCA.

~~~sh
80 [ CA_default ]
81
82 dir             = /home/genildom/ca       # Where everything is kept
84 crl_dir         = $dir/crl              # Where the issued crl are kept
85 database        = $dir/index.txt        # database index file.
86 #unique_subject = no                    # Set to 'no' to allow creation of
87                                         # several certs with same subject.
88 new_certs_dir   = $dir/newcerts         # default place for new certs.
89
90 certificate     = $dir/cacert.pem       # The CA certificate
91 serial          = $dir/serial           # The current serial number
92 crlnumber       = $dir/crlnumber        # the current crl number
93                                         # must be commented out to leave a V1 CRL
94 crl             = $dir/crl.pem          # The current CRL
95 private_key     = $dir/private/cakey.pem# The private key
~~~

Executar o comando que ira gerar o certificado com base no "CSR".

~~~bash
openssl ca -config ./openssl.cnf -in fortigate.csr -out fortigate-cert.pem
~~~

Ao executar o comando, as seguintes informações serão solicitadas.

~~~bash
Using configuration from ./openssl.cnf
Enter pass phrase for /home/genildom/ca/private/cakey.pem:
Check that the request matches the signature
Signature ok
Certificate Details:
        Serial Number: 4096 (0x1000)
        Validity
            Not Before: Aug  2 02:44:20 2025 GMT
            Not After : Aug  2 02:44:20 2026 GMT
        Subject:
            countryName               = BR
            stateOrProvinceName       = Sao Paulo
            organizationName          = Genildo Martins WebTips
            organizationalUnitName    = Firewall Fortigate
            commonName                = firewall-01
            emailAddress              = genildovsm@gmail.com
        X509v3 extensions:
            X509v3 Basic Constraints:
                CA:FALSE
            X509v3 Subject Key Identifier:
                B4:A6:0D:BA:C2:96:37:63:AA:19:F8:78:EC:32:FC:CE:FE:D3:01:12
            X509v3 Authority Key Identifier:
                62:16:44:11:EA:B2:F2:C7:C9:ED:14:C6:78:0B:3F:2C:8D:16:5D:96
Certificate is to be certified until Aug  2 02:44:20 2026 GMT (365 days)
Sign the certificate? [y/n]:y


1 out of 1 certificate requests certified, commit? [y/n]y
Write out database with 1 new entries
Database updated
~~~

Agora vamos gerar o certificado para o usuário.

~~~bash
openssl genrsa -out genildowebtips-key.pem 4096
~~~

Em seguida criar a solicitação do certificado assinado "CSR".

~~~bash 
openssl req -new -key genildowebtips-key.pem -out genildowebtips.csr
~~~

As seguintes informações serão solicitadas.

~~~bash
You are about to be asked to enter information that will be incorporated
into your certificate request.
What you are about to enter is what is called a Distinguished Name or a DN.
There are quite a few fields but you can leave some blank
For some fields there will be a default value,
If you enter '.', the field will be left blank.
-----
Country Name (2 letter code) [AU]:BR
State or Province Name (full name) [Some-State]:Sao Paulo
Locality Name (eg, city) []:Praia Grande
Organization Name (eg, company) [Internet Widgits Pty Ltd]:Genildo Martins WebTips
Organizational Unit Name (eg, section) []:
Common Name (e.g. server FQDN or YOUR name) []:Odin
Email Address []:genildovsm@gmail.com

Please enter the following 'extra' attributes
to be sent with your certificate request
A challenge password []:admin@123
An optional company name []:
~~~

Gerar o certificado assinado para o usuário com base no "CSR".

~~~bash
openssl ca -config openssl.cnf -in genildowebtips.csr -out genildowebtips-cert.pem
~~~

### Exportar os certificados para um formato adequado "CRT".  

Exportando o certificado da RootCA

~~~bash
openssl x509 -in cacert.pem -out rootCA_OpenSSl.crt
~~~

Exportar os certificados do dispositivo e do usuário para o formato **pkcs12**.

~~~bash
openssl pkcs12 -export -out fortigate.p12 -inkey fortigate-key.pem -in fortigate-cert.pem -certfile cacert.pem
~~~

Informar a senha para o certificado gerado

~~~bash
Enter Export Password:
Verifying - Enter Export Password:
~~~

Exportar o certificado do usuário.

~~~bash
openssl pkcs12 -export -out genildowebtips.p12 -inkey genildowebtips-key.pem -in genildowebtips-cert.pem -certfile cacert.pem
~~~

Informar a senha para o certificado gerado

~~~bash
Enter Export Password:
Verifying - Enter Export Password:
~~~

#### Finalizando o processo

- Importar os arquivos **rootCA_OpenSSL.crt** e **fortigate.p12** para o dispositivo de firewall.
- Importar os arquivos **rootCA_OpenSSL.crt** e **genildowebtips.p12** para o cliente.
