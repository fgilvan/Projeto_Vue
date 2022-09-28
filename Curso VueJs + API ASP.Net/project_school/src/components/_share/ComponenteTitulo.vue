<template>
  <div>
    <div style="display: flex;  width: 50%;">
      <h2>{{ texto }}</h2>
      <div class="voltar">
        <slot></slot>
        <button v-show="btnVoltar" class="btn btnVoltar" @click="voltar()">Voltar</button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    texto: String,
    btnVoltar: Boolean
  },
  methods:{
    voltar(){
      window.history.length > 1 ? this.$router.go(-1) : this.$router.push('/')
    }
  }
};
</script>

<style scoped>
.voltar {
  width: 50%;
  position: absolute;
  margin-top: 15px;
}
.btnVoltar {
  float: right;
  background: rgb(199, 199, 199);
}
</style>
