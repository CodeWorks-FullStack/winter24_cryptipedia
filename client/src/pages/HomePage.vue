<script setup>

</script>

<template>
  <div class="container-fluid forest-bg">
    <section class="row shadow-layer">
      <div class="col-md-7 align-self-center">
        <div class="p-5 text-light">
          <h1>Terrestrials</h1>
          <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptatem ipsum dolore culpa sint, dolor aliquam
            blanditiis soluta minus commodi quos veritatis voluptas officiis quia distinctio esse, quam obcaecati
            perspiciatis, sed quidem quasi. Obcaecati itaque consectetur laborum illo adipisci reprehenderit accusamus
            amet iusto expedita doloribus! Non cupiditate vero itaque omnis. Consequuntur!</p>
        </div>
      </div>
      <div class="col-md-5 align-self-end">
        <img src="/public/img/cryptid_cat.png" alt="Cryptid cat" class="img-fluid">
      </div>
    </section>
  </div>
</template>

<style scoped lang="scss">
.forest-bg {
  background-image: url(https://images.unsplash.com/photo-1446553009413-64b9505cacb0?q=80&w=2340&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D);
  background-size: cover;
}

.shadow-layer {
  backdrop-filter: blur(2px);
  background-color: rgba(0, 0, 0, 0.5);


  h1,
  p {
    text-shadow: 1px 1px black;
  }

  img {
    filter: hue-rotate(-100deg);
  }
}
</style>
