
mepArr = [
    [0, 0],
    [0, 1]
]

mepCols = [
    'rgb(122, 228, 255)', // water
    'rgb(224, 224, 145)', // beach
    'rgb(219, 219, 195)', // scorched
    'rgb(188, 188, 167)', // bare
    'rgb(213, 229, 224)', // tundra
    'rgb(242, 242, 242)', // snow
    'rgb(218, 237, 149)', // temperate desert
    'rgb(214, 189, 0)',  // shrubland
    'rgb(110, 209, 176)', // taiga
    'rgb(92, 142, 5)',   // grassland
    'rgb(123, 175, 33)', // temperate deciduous forest
    'rgb(67, 140, 12)', // temperate rainforest
    'rgb(216, 175, 28)', // subtropical desert
    'rgb(103, 137, 67)', // tropical seasonal forest
    'rgb(16, 114, 8)',  // temperate rainforest
]

let drew = document.getElementById('drew')
let ctx = drew.getContext('2d')
let drawWidth = drew.getAttribute('width')
let drawHeight = drew.getAttribute('height')

ctx.fillStyle = 'rgb(250,250,250)'

function clearMep() {
    ctx.fillRect(0, 0, drawWidth, drawHeight)
}

function redrawMep() {
    clearMep()

    let mepW = mepArr[0].length
    let mepH = mepArr.length
    let tilS = Math.floor(drawWidth / mepW)
    // let tilH = drawHeight / mepH

    for (let i = 0; i < mepH; i++) {
        for (let j = 0; j < mepW; j++) {
            let v = mepArr[i][j]
            ctx.fillStyle = mepCols[v]
            ctx.fillRect(j * tilS, i * tilS, tilS, tilS)
        }
    }
}

redrawMep()
