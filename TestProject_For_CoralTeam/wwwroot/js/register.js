var counter = 1;
const elements = {
    "1": ["Salutation","Email","firstName","ConfirmEmail","MiddleName","Phone","LastName","Fax","Company","Mobile","Title"],
    "2": ["Finance", "Comments"],
    "3": ["Country", "OfficeName", "Address", "PostalCode", "City", "State"],
    "4": ["Password", "ConfirmPassword", "Cap"],
    "5": ["LastPage"]
};
var nextButton = document.getElementById('nextButton');
var backButton = document.getElementById('prevButton');

function newStep() {  
    let ul = document.getElementById('step');
    let div = document.getElementById('UnderHeader');
    let prevButton = document.getElementById('prevButton');
    elements[counter].forEach((el) => {        
        document.getElementById(el).parentElement.hidden = true;        
    });  

    div.children[counter - 1].hidden = true;
    counter++;
    if (counter > 1) {
        prevButton.hidden = false;
    }
    
    div.children[counter - 1].hidden = false;
    ul.children[counter - 1].className = 'active';
    elements[counter].forEach(el => {


        document.getElementById(el).parentElement.hidden = false;
    });
    
  
      
}



async function CheckResponse() {

    let response = await fetch("https://localhost:44330/", { method: 'POST' });
    if (response.status == 200) {
        div.children[counter - 1].hidden = false;
        ul.children[counter - 1].className = 'active';
        elements[counter].forEach(el => {


            document.getElementById(el).parentElement.hidden = false;
        });
    }
}







function prevStep() {
    let ul = document.getElementById('step');
    let div = document.getElementById('UnderHeader');
    let prevButton = document.getElementById('prevButton');
    elements[counter].forEach((el) => {
        document.getElementById(el).parentElement.hidden = true;
    });
    div.children[counter - 1].hidden = true;
    ul.children[counter - 1].className = '';
    counter--;
    if (counter == 1) {
        prevButton.hidden = true;
    }
    div.children[counter - 1].hidden = false;
    elements[counter].forEach(el => {


        document.getElementById(el).parentElement.hidden = false;
    });   
}





function checkRequired() {   
    for (let id of elements[counter]) {
        let node = document.getElementById(id);
        if (node.hasAttribute('required') && node.value === '') {
            return false;
        }        
    }
    return true;
}

nextButton.addEventListener('click', (e) => {
    //e.preventDefault();
    
    if (checkRequired()) {
        newStep();
    }

    if (counter == 5) {
        //document.getElementsByTagName("form")[0].submit();
        const data = new URLSearchParams();
        for (const pair of new FormData(document.getElementsByTagName("form")[0])) {
            data.append(pair[0], pair[1]);
        }

        fetch("https://localhost:44330/",
            {
                method: 'POST',
                body: data
            })
            .then(response => {
                console.log(response);
                if (response.status == 400) {
                    //console.log('400');
                    document.getElementsByTagName("form")[0].submit();
                }
                if (response.status == 200) {
                    console.log("200");
                    document.getElementById('error').hidden = true;
                }
            })

        nextButton.hidden = true;
        prevButton.hidden = true;

    }

});


backButton.addEventListener('click', () => {
    prevStep();
});
