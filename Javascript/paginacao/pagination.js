const tabela_tbody = document.querySelector('#tbl_produtos tbody')
const query = 'nome=Maria&cidade=Parana&cep=11721090'
const ul_nav = document.querySelector('#nav_pagination ul')

const intervalo = 5
const ipp = 10
var pagina = 1

document.addEventListener('DOMContentLoaded', ()=>{ 
    
    carregar(1)

})


async function carregar(pg){    
    
    let resp = await fetch('./produtos.json')

    if (!resp.ok){
        console.error('Erro ao ler o arquivo')
        return
    }

    const produtos = await resp.json()

    if (produtos.length > 0){
        ul_nav.innerHTML = `<li class="active"><a href="javascript:void(0)">${pg}</a></li>`
    }

    let pagina = pg ?? 1
    let inicio = (pagina-1) * ipp
    let total_paginas = Math.ceil(produtos.length/ipp)
    let aux_intervalo, aux_pagina, aux_html

    aux_pagina = (pagina - intervalo > 1) ? (pagina - intervalo) : 2
    aux_intervalo = intervalo
    aux_html = ''

    while(aux_pagina < pagina){
        aux_html += `<li><a href="javascript:void(0)" onclick=carregar(${aux_pagina})>${aux_pagina}</a></li>`
        aux_pagina ++
    }

    ul_nav.innerHTML = aux_html + ul_nav.innerHTML

    aux_pagina = pagina + 1
    aux_intervalo = intervalo

    while( aux_pagina < total_paginas && aux_intervalo > 0 ){
        ul_nav.innerHTML += `<li><a href="javascript:void(0)" onclick=carregar(${aux_pagina})>${aux_pagina}</a></li>`
        aux_pagina ++
        aux_intervalo --
    }

    let aux_resultados = ''

    for (let i=inicio; i < inicio + ipp; i++){        
        aux_resultados +=
            `<tr>
                <td>${produtos[i].id}</td>
                <td>${produtos[i].categoria}</td>
                <td>${produtos[i].preco}</td>
                <td>${produtos[i].descricao}</td>
            </tr>`
    }

    tabela_tbody.innerHTML = aux_resultados
    
}
