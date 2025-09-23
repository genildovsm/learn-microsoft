const txt_nome = document.querySelector('#nome')
const rb_digital = document.querySelectorAll('input[type="radio"]')

document.getElementById('btn-interagir').onchange = (e) => {

    if (e.target.checked){

        rb_digital.forEach(el => {
            el.onclick = (e) => {
                e.preventDefault()
            }
        })

        txt_nome.setAttribute('readonly','')

    } else {

        rb_digital.forEach(el => {
            el.onclick = null
        })

        txt_nome.removeAttribute('readonly')
    }
}

document.forms[0].onsubmit = (e) => {
    e.preventDefault()

    let frm = new FormData(e.target)
    let entries = frm.entries()
    let json = Object.fromEntries(entries)

    console.log(json)
}
