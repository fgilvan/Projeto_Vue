import { createWebHistory, createRouter } from "vue-router";

import ComponenteAlunos from "./components/Aluno/ComponenteAlunos.vue";
import ComponenteProfessores from "./components/Professor/ComponenteProfessor.vue";
import ComponenteSobre from "./components/Sobre/ComponenteSobre.vue";

const routes = [
        {
            path: '/professores',
            nome: 'Professores',
            component: ComponenteProfessores
        },{
            path: '/alunos/:prof_id',
            nome: 'Alunos',
            component: ComponenteAlunos
        },{
            path: '/todosalunos',
            nome: 'Alunos',
            component: ComponenteAlunos
        },{
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