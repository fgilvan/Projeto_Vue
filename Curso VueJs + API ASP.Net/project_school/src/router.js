import { createWebHistory, createRouter } from "vue-router";

import ComponenteAlunos from "./components/Aluno/ComponenteAlunos.vue";
import ComponenteProfessores from "./components/Professor/ComponenteProfessor.vue";
import ComponenteSobre from "./components/Sobre/ComponenteSobre.vue";
import ComponenteAlunoDetalhe from "./components/Aluno/ComponenteAlunoDetalhe.vue";

const routes = [
        {
            path: '/professores',
            nome: 'Professores',
            component: ComponenteProfessores
        },{
            path: '/alunos/:prof_id',
            nome: 'AlunosPorProfessor',
            component: ComponenteAlunos
        },{
            path: '/todosalunos',
            nome: 'Alunos',
            component: ComponenteAlunos
        },{
            path: '/alunoDetalhe/:id',
            nome: 'AlunosDetalhe',
            component: ComponenteAlunoDetalhe
        }
        ,{
            path: '/sobre',
            nome: 'Sobre',
            component: ComponenteSobre
        },
    ];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;