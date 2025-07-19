String.prototype._isDate = function(){
    
    const strData = this.valueOf()
    const reDataBR = /^(?<dia>\d{2})[/-](?<mes>\d{2})[/-](?<ano>\d{4})$/
    const reDataUS = /^(?<ano>\d{4})[/-](?<mes>\d{2})[/-](?<dia>\d{2})$/ 
    const mes31dias = [1,3,5,7,8,10,12] 

    let match
    let dia,mes,ano      

    function valida (p_dia, p_mes, p_ano) {
        try {

            if (strData.split('-').length != 3 && strData.split('/').length != 3)
                throw 'Use duas "/" ou  dois "-" como separadores.'

            if (p_dia < 1 || p_dia > 31 || p_mes < 1 || p_mes > 12 || p_ano < 1000)
                return false

            if (p_dia > 30 && (!mes31dias.includes(p_mes)))
                return false

            if (p_dia > 28 && p_mes == 2 && p_ano % 4 != 0)
                return false 

        } catch(err){

            console.error(err)
            return false
        }               
        
        return true
    }

    if (reDataBR.test(strData)){
        match = strData.match(reDataBR)
        dia = match.groups.dia
        mes = match.groups.mes
        ano = match.groups.ano
        return valida(dia,mes,ano)        
    }

    if (reDataUS.test(strData)){
        match = strData.match(reDataUS)
        dia = match.groups.dia
        mes = match.groups.mes
        ano = match.groups.ano
        return valida(dia,mes,ano)        
    }

    return false    
}

console.log( '2025-09-30'._isDate() )
