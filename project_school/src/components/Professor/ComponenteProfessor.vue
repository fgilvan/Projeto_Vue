<template>
  <div>
    <ComponenteTitulo texto="Professores" />
    <table>
      <thead>
        <th>Código.</th>
        <th>Nome</th>
        <th>Alunos</th>
      </thead>
      <tbody v-if="professores.length > 0">
        <tr v-for="(professor, index) in professores" :key="index">
          <td>{{ professor.id }}</td>
          <router-link
            v-bind:to="`/alunos/${professor.id}`"
            custom
            v-slot="{ navigate }"
          >
            <td @click="navigate" style="cursor: pointer">
              {{ professor.nome }} {{ professor.sobrenome }}
            </td>
          </router-link>
          <td>
            {{ professor.qtdAlunos }}
          </td>
        </tr>
      </tbody>
      <tfoot v-else>
        Nenhum professor encontrado.
      </tfoot>
    </table>
  </div>
</template>

<script>
import ComponenteTitulo from "../_share/ComponenteTitulo.vue";
import Api from "../../services/api.ts";

export default {
  components: {
    ComponenteTitulo,
  },
  data() {
    return {
      professores: [],
      alunos: [],
    };
  },
  created() {
    Api.get("/alunos").then((alunos) => {
      this.alunos = alunos.data;
      this.carregarProfessores();
    });
  },
  methods: {
    ObtemQtdAlunosPorProfessor() {
      this.professores.forEach((professor, index) => {
        professor = {
          id: professor.id,
          nome: professor.nome,
          qtdAlunos: this.alunos.filter(aluno => aluno.professor.id == professor.id).length,
        };

        this.professores[index] = professor;
      });
    },
    carregarProfessores() {
      Api.get("/professores").then((professores) => {
        this.professores = professores.data;
        this.ObtemQtdAlunosPorProfessor();
      });
    },
  }
};
</script>

<style lang="scss" scoped>
</style>
