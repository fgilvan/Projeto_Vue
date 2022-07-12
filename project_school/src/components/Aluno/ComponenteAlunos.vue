<template>
  <div>
    <ComponenteTitulo
      :texto="professorid ? 'Professor: ' + professoratual.nome : 'Aluno'"
    />

    <div v-if="professorid != undefined">
      <input
        type="text"
        v-on:keyup.enter="addAluno"
        placeholder="Nome do Aluno"
        v-model="nome"
      />
      <button @click="addAluno" class="btn btnInput">Adicionar</button>
    </div>

    <table>
      <thead>
        <th>Mat.</th>
        <th>Nome</th>
        <th>Opções</th>
      </thead>
      <tbody v-if="alunos.length > 0">
        <tr v-for="aluno in alunos" :key="aluno.id">
          <td>{{ aluno.id }}</td>
          <td>{{ aluno.nome }} {{ aluno.sobrenome }}</td>
          <td>
            <button class="btn btn_Danger" @click="remover(aluno)">
              Remover
            </button>
          </td>
        </tr>
      </tbody>
      <tfoot v-else>
        Nenhum aluno encontrado.
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
      titulo: "Aluno",
      professorid: this.$route.params.prof_id,
      professoratual: {},
      nome: "",
      alunos: [],
    };
  },
  created() {
    if (this.professorid) {
      this.carregueProfessorAtual(this.professorid);
      Api.get("/alunos/?professor.id=" + this.professorid).then(
        (alunos) => (this.alunos = alunos.data)
      );
    } else {
      Api.get("/alunos").then((alunos) => (this.alunos = alunos.data));
    }
  },
  methods: {
    addAluno() {
      let _aluno = {
        nome: this.nome,
        sobrenome: this.sobrenome,
        professor: this.professoratual,
      };

      Api.post("/alunos", _aluno).then((res) => {
        if (!res.data) {
          return;
        }

        _aluno.id = res.data.id;
        this.alunos.push(_aluno);
        this.nome = "";
      });
    },
    remover(aluno) {
      var indice = this.alunos.indexOf(aluno);

      Api.delete(`/alunos/${aluno.id}`);

      this.alunos.splice(indice, 1);
    },
    carregueProfessorAtual(idProfessor) {
      Api.get("/professores/" + idProfessor).then((professor) => {
        this.professoratual = professor.data;
      });
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
input {
  width: calc(100% - 195px);
  border: 0;
  padding: 20px;
  font-size: 1.3em;
  color: #687f7f;
  display: inline;
}

.btnInput {
  width: 150px;
  border: 0px;
  padding: 20px;
  font-size: 1.3em;
  background-color: rgb(116, 115, 115);
  display: inline;
}

.btnInput:hover {
  padding: 20px;
  margin: 0px;
  border: 0px;
}
</style>
