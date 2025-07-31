const obj = [
    {id: 1, name:"Geladeira", price: 3000.00, discount: 0.2},
    {id: 2, name:"Tanquinho", price: 2564.50, discount: 0.15},
    {id: 3, name:"Fogão", price: 1430.78, discount: 0},
]

const obj1 = obj.map((v, i, a) =>{
    v.price = v.discount > 0 ? v.price - v.price * v.discount : v.price
    v.price = v.price.toLocaleString('pt-br', {style: 'currency', currency: 'BRL'})    
    return v
})

const obj2 = obj1.filter(v => v.id > 1)

console.log(obj2)