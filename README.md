# TestTask

- Создан скрипт Bootrap.cs с кодом реализации первого задания
- Создан скрипт IHaveProjectileReaction.cs реализующий интерфейс IHaveProjectileReaction с методом React()
- Создан скрипты BloodReaction.cs, ConcreteReaction.cs, MetalReaction.cs, DirtReaction.cs в которых реализуется метод React() для объектов данного типа
- Проведён рефакторинг скрипта Projectile.cs метода OnCollisionEnter, теперь проверка коллизии зависит от содержания интерфейса у объекта
- Проведён рефакторинг скриптов GasTankScript.cs, ExplosiveBarrelScript.cs, TargetScript.cs, в соответсвующих клкассах был реализован метод React()

В первом задание особо отмечать ничего, всё было понятно и сделано по тз. 

Во втором задании уже были вопросы, с бочками, мишенями и балонами было всё понятно, а вот что сделать с тегами dirt concrete blood metal я не очень понял.
Соотвествующих классов я не нашёл, были только объекты с тегами. Объекта с тегом dirt я вобще не нашёл, а с тегом blood видел 1 тип, уже не уверен он был постоянным или создавался в процессе игры.
В итоге я просто написал скрипты типа ConcreteReaction.cs для каждого тега, и навесил его на все объекты с соотвествующим тегом, если точнее то на все concrete и metal объекты.
Также подправил объекты metal (сферы в art комнате) теперь игрок не может пройти сквозь них и пули также не пролетают насквозь, а реагируют на столкновении согласно логиике оставляя следы.
Ещё поменял создание префабов для объектов с тегами dirt concrete blood metal. Все они создавались с учётом количества элементов в bloodPrefab что странно, изменил на соответсвющии объейкты (concrete зависит от concretePrefab и тд.).
