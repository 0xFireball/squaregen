function handleFileSelect(evt) {
    var files = evt.target.files; // FileList object

    // use the 1st file from the list
    f = files[0];

    var reader = new FileReader();

    // Closure to capture the file information.
    reader.onload = (function (theFile) {
        return function (e) {
            let mepDeta = e.target.result
            let lins = mepDeta.split('\n')
            let dimsS = lins[0].split('x')
            let w = parseInt(dimsS[0])
            let h = parseInt(dimsS[1])

            mepArr = []

            for (let i = 1; i < h; i++) {
                let mepL = lins[i]
                let dets = mepL.split(',').map(x => parseInt(x))
                
                mepArr.push(dets)
            }
            
            console.log('loaded new mep', mepArr)
            redrawMep()
        };
    })(f);

    // Read in the image file as a data URL.
    reader.readAsText(f);
}

document.getElementById('upload').addEventListener('change', handleFileSelect, false);