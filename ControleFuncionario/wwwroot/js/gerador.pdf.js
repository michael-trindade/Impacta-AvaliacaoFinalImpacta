$(document.body).ready(function () {
    //Remover navbar
    $('nav').remove();
    //Colocar altura no footer para usar como margem
    $('header').height('100px');
    //Remover caracter '|'
    $('div').html($('div').html().replace('|', ''));
    //Remover botões
    $('a').remove();
    //Remover rodapé
    $('footer').remove();
    //Criar PDF
    var doc = new jsPDF('l', 'pt', 'a4');
    //Adicionar conteúdo no PDF
    doc.addHTML(document.body, function () {
        //Salvar
        //doc.save('html.pdf');
        //Abrir relatório
        var string = doc.output('datauristring');
        var embed = "<embed width='100%' height='100%' src='" + string + "'/>"
        location.replace("/");
        var x = window.open();
        x.document.write(embed);
    });
});