// CONFIGURAÇÃO BASE DA API (.NET)
const BASE_URL_API = "http://localhost:5036"; 

// 1. TELA: MATRIZ CURRICULAR (matriz-curricular.html)
async function salvarMatrizCurricular(event) {
    event.preventDefault(); // Evita que a página recarregue ao enviar

    // Capturando os dados dos inputs do HTML
    const curso = document.getElementById('curso').value;
    const modalidade = document.getElementById('modalidade').value;
    const cargaHoraria = document.getElementById('carga-horaria').value;
    const grau = document.getElementById('grau').value;

    // Montando o objeto JSON para o Back-end
    const dadosMatriz = {
        curso: curso,
        modalidade: modalidade,
        cargaHoraria: cargaHoraria,
        grau: grau
    };

    console.log("Enviando Matriz Curricular:", dadosMatriz);

    try {
        const response = await fetch("http://localhost:5036/api/matriz-curricular", {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(dadosMatriz)
        });

        if (response.ok) {
            alert("Matriz Curricular salva com sucesso!");
            event.target.reset(); // Limpa o formulário
        } else {
            alert("Erro ao salvar Matriz Curricular.");
        }
    } catch (error) {
        console.error("Erro na requisição da Matriz:", error);
    }
}

// 2. TELA: PROFESSORES (professores.html)
async function salvarProfessor(event) {
    event.preventDefault();

    const nome = document.getElementById('nome').value;
    const email = document.getElementById('email').value;

    const dadosProfessor = {
        nome: nome,
        email: email,
    };

    console.log("Enviando Professor:", dadosProfessor);

    try {
        const response = await fetch("http://localhost:5036/api/professores", {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(dadosProfessor)
        });

        if (response.ok) {
            alert("Professor cadastrado com sucesso!");
            event.target.reset();
        } else {
            alert("Erro ao cadastrar professor.");
        }
    } catch (error) {
        console.error("Erro na requisição de Professor:", error);
    }
}

// ==========================================================================
// 3. TELA: DISCIPLINAS (disciplinas.html)
// ==========================================================================
async function salvarDisciplina(event) {
    event.preventDefault();

    const nome = document.getElementById('nome-disciplina').value;
    const curso = document.getElementById('curso-disciplina').value;
    const cargaHoraria = document.getElementById('carga-disciplina').value;

    const dadosDisciplina = {
        nome: nome,
        curso: curso,
        cargaHoraria: cargaHoraria
    };

    console.log("Enviando Disciplina:", dadosDisciplina);

    try {
        const response = await fetch(`${BASE_URL_API}/api/disciplinas`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(dadosDisciplina)
        });

        if (response.ok) {
            alert("Disciplina salva com sucesso!");
            event.target.reset();
        } else {
            alert("Erro ao salvar disciplina.");
        }
    } catch (error) {
        console.error("Erro na requisição de Disciplina:", error);
    }
}

// ==========================================================================
// 4. TELA: DISPONIBILIDADE DO PROFESSOR (disponibilidade-professor.html)
// ==========================================================================
async function salvarDisponibilidade(event) {
    event.preventDefault();

    // Pega todas as caixinhas (checkboxes) que o usuário marcou
    const checkboxesMarcados = document.querySelectorAll('input[name="disponibilidade"]:checked');
    
    // Cria uma lista apenas com os dias escolhidos (ex: ["segunda", "quarta"])
    const diasSelecionados = Array.from(checkboxesMarcados).map(cb => cb.value);

    const dadosDisponibilidade = {
        // Na união do grupo, vocês vão ver se o back precisa do ID do professor aqui também
        diasSemana: diasSelecionados
    };

    console.log("Enviando Disponibilidade:", dadosDisponibilidade);

    try {
        const response = await fetch(`${BASE_URL_API}/api/disponibilidade`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(dadosDisponibilidade)
        });

        if (response.ok) {
            alert("Disponibilidade salva com sucesso!");
        } else {
            alert("Erro ao salvar disponibilidade.");
        }
    } catch (error) {
        console.error("Erro na requisição de Disponibilidade:", error);
    }
}