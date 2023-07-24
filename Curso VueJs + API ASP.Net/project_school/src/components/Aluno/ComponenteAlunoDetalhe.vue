<template>
  <div v-if="!loading">
    <ComponenteTitulo :texto="`Aluno: ${aluno.nome}`" :btnVoltar="editar">
      <button v-show="!editar" @click="Editar()" class="btn btnEditar">Editar</button>
    </ComponenteTitulo>
    <table>
      <tbody>
        <tr>
          <td class="colPequeno">Matrícula:</td>
          <td>
            <label>
              {{ aluno.id }}
            </label>
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Nome:</td>
          <td>
            <input v-model="aluno.nome" type="text" v-if="editar" />
            <label v-else>
              {{ aluno.nome }}
            </label>
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Sobrenome:</td>
          <td>
            <input v-model="aluno.sobrenome" type="text" v-if="editar" />
            <label v-else>
              {{ aluno.sobrenome }}
            </label>
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Data de Nascimento:</td>
          <td>
            <input v-model="aluno.dataNasc" type="text" v-if="editar" />
            <label v-else>
              {{ aluno.dataNasc }}
            </label>
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Professor:</td>
          <td>
            <select v-model="aluno.professor.id" v-if="editar">
              <option
                v-for="(professor, index) in this.professores"
                :key="index"
                v-bind:value="professor.id"
              >
                {{ professor.nome }}
              </option>
            </select>
            <label v-else>
              {{ aluno.professor.nome }}
            </label>
          </td>
        </tr>
      </tbody>
    </table>
    <div  style="margin-top:10px">
      <div v-if="editar">
        <button class="btn btnSalvar" @click="salvar">Salvar</button>
        <button class="btn btnCancelar" @click="cancelar">Cancelar</button>
      </div>
    </div>
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
      aluno: {},
      professores: [],
      alunoId: this.$route.params.id,
      editar: false,
      loading: true
    };
  },
  created() {
    this.CarregueProfessores();
  },
  methods: {
    CarregueProfessores() {
      Api.get("/professor").then((professores) => {
        this.professores = professores.data;
        this.CarregueAluno();
      });
    },
    CarregueAluno() {
      if (this.alunoId) {
        Api
        .get("/aluno/" + this.alunoId)
        .then(
          (alunos) => {
            this.aluno = alunos.data;
            this.loading = false;
          }
        );
      }
    },
    Editar() {
      this.editar = !this.editar;
    },
    salvar(){
      let _alunoEditar = {
        id: this.aluno.id,
        nome: this.aluno.nome,
        sobrenome: this.aluno.sobrenome,
        dataNasc: this.aluno.dataNasc,
        professorid: this.aluno.professor.id
      }

      Api
      .put("/aluno/" + _alunoEditar.id, _alunoEditar)
      .then((aluno) => {
        this.aluno = aluno.data;
        this.editar = !this.editar;
      });

      //window.history.length > 1 ? this.$router.go(-1) : this.$router.push('/')
    },
    cancelar(){
      this.editar = !this.editar;
    }
  },
};
</script>

<style scoped>
.btnEditar {
  float: right;
  background: rgb(76, 186, 249);
}
.btnSalvar {
  float: right;
  background: rgb(79,196, 68);
}
.btnCancelar {
  float: right;
  background: rgb(249, 92,92);
  float: left;
}
.colPequeno {
  width: 20%;
}
input,
select {
  margin: 0;
  padding: 5px 0px;
  font-size: 0.9em;
  border: 1px solid silver;
  border-radius: 5px;
  font-family: MontSerrat;
  width: 95%;
  background-color: rgb(245, 245, 245);
}
select {
  height: 38px;
  width: 100%;
}
</style>
